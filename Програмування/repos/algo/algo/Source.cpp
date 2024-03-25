#include <iostream>
#include <chrono>

const int rows = 500;
const int cols = 500;

std::chrono::steady_clock::time_point begin;
std::chrono::steady_clock::time_point end;

void main() {
	int** arr = new int* [rows];
	for (size_t i = 0; i < rows; ++i)
		arr[i] = new int[cols];

	for (size_t i = 0; i < rows; i++)
		for (size_t j = 0; j < cols; j++) {
			arr[i][j] = rand() % 100 + 1;
		}

	int size = rows * cols;
	int* vec = new int[size];
	int k = 0;
	for (size_t i = 0; i < rows; i++)
		for (size_t j = 0; j < cols; j++)
			vec[k++] = arr[i][j];

	// ------------------------------------------------------------------------
	begin = std::chrono::steady_clock::now();

	int max3 = 0;
	int** ptr = arr;
	for (int i = 0; i < rows; i++) {
		int* curr = *ptr;
		for (int j = 0; j < cols; j++) {
			if (max3 < *curr) {
				max3 = *curr;
			}
			curr++;
		}
		ptr++;
	}

	end = std::chrono::steady_clock::now();

	std::cout << "Time difference = " << std::chrono::duration_cast<std::chrono::microseconds>(end - begin).count() << "[mcrs]" << std::endl;
	std::cout << "Time difference = " << std::chrono::duration_cast<std::chrono::nanoseconds> (end - begin).count() << "[ns]" << std::endl << std::endl;
	// ------------------------------------------------------------------------
	begin = std::chrono::steady_clock::now();

	int max = 0;
	for (size_t i = 0; i < rows; i++)
		for (size_t j = 0; j < cols; j++)
			if (max < arr[i][j])
				max = arr[i][j];
	
	end = std::chrono::steady_clock::now();

	std::cout << "Time difference = " << std::chrono::duration_cast<std::chrono::microseconds>(end - begin).count() << "[mcrs]" << std::endl;
	std::cout << "Time difference = " << std::chrono::duration_cast<std::chrono::nanoseconds> (end - begin).count() << "[ns]" << std::endl << std::endl;
	// ------------------------------------------------------------------------
	begin = std::chrono::steady_clock::now();

	int max2 = 0;
	for (size_t i = 0; i < size; i++)
		if (max2 < vec[i])
			max2 = vec[i];

	end = std::chrono::steady_clock::now();

	std::cout << "Time difference = " << std::chrono::duration_cast<std::chrono::microseconds>(end - begin).count() << "[mcrs]" << std::endl;
	std::cout << "Time difference = " << std::chrono::duration_cast<std::chrono::nanoseconds> (end - begin).count() << "[ns]" << std::endl << std::endl;	
	// ------------------------------------------------------------------------
}