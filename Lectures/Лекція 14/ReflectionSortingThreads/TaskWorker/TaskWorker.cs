using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWorker
{
    public class InTaskSorter : IDisposable
    {
        private CancellationTokenSource tokenSource; // для одноразового генерування токенів
        private Progress<(int index, int value)> progress;            // звітує парою <індекс, значення>
        private int[] array;                         // передає в метод сортування, може змінитися
        private MethodInfo sortMethod;               // один з методів сортування, може змінитися
        private Action continuation;

        public InTaskSorter()
        {
            tokenSource = new CancellationTokenSource();   // джерело токенів точно потрібне
            progress = null;                               // задає візуальна компонента - один зі своїх методів
            array = null;                                  // регулярно змінюється після генерування, задає компонента
            sortMethod = null;                             // змінюється вибором в компоненті
            continuation = null;
        }
        public void Dispose()
        {
            tokenSource.Dispose();
        }
        public void SetArray(int[] a)
        {
            array = a;
        }
        public void SetMethod(MethodInfo s)
        {
            sortMethod = s;
        }
        public void SetProgress(Action<(int index, int value)> p)
        {
            progress = new Progress<(int index, int value)>(p);
        }
        public void SetContinuation(Action c)
        {
            continuation = c;
        }
        public void Stop()
        {
            tokenSource.Cancel();
        }
        public async void Start()
        {
            if (tokenSource.Token.IsCancellationRequested) // використаний токен треба замінити
            {
                tokenSource.Dispose();
                tokenSource = new CancellationTokenSource();
            }
            await Task.Run(() =>
            {
                sortMethod?.Invoke(null, new object[] { array, tokenSource.Token, progress });
            }, tokenSource.Token);
            continuation();
        }
    }
}
