#include <fstream>
#include <string>
#include <cstdlib>
#include <ctime>
#include <cmath>	

float RandomNumber(float Min, float Max)
{
	return ((float(rand()) / float(RAND_MAX)) * (Max - Min)) + Min;
}

void main() 
{
	srand(static_cast <unsigned> (time(0)));

	std::ofstream file("info.json");

	float previous= RandomNumber(7, 9);

	if (file.is_open()) {
		file << "[";

		int date = 15, month = 3;
		for (size_t i = 1; i <= 90; ++i)
		{
			file << "\n\t{\n";
			if (date < 10)
				file << "\t\t\"date\": \"2021-0" << month << "-0" << date << "\",\n";
			else
				file << "\t\t\"date\": \"2021-0" << month << "-" << date << "\",\n";

			int minutes = rand() % 60;
			std::string minut = "";
			if (minutes < 10) minut = "0" + std::to_string(minutes);
			else minut = std::to_string(minutes);

			if (i % 3 == 1)
				file << "\t\t\"time\": \"0" << rand() % 2 + 8 << ":" << minut << "\",\n";
			else if (i % 3 == 2)
				file << "\t\t\"time\": \"" << rand() % 2 + 14 << ":" << minut << "\",\n";
			else 
			{
				file << "\t\t\"time\": \"" << 19 << ":" << minut << "\",\n";
				date++;
				if (date == 32) { date = 1; month = 4; }
			}

			if (previous <= 10 && previous >= 5.5)
				previous = previous + RandomNumber(-2.5, 2.5);
			else if (previous > 10)
				previous = previous + RandomNumber(-2.5, 0);
			else
				previous = previous + RandomNumber(0, 2.5);

			file << "\t\t\"sugarBeforeMeal\": " << std::ceil(previous * 10.0) / 10.0 << ",\n";

			if (previous <= 10 && previous >= 5.5)
				previous = previous + RandomNumber(-3, 3);
			else if (previous > 10)
				previous = previous + RandomNumber(-3, 0);
			else
				previous = previous + RandomNumber(0, 3);

			file << "\t\t\"sugarAfterMeal\": " << std::ceil(previous * 10.0) / 10.0 << ",\n";

			int CHO = rand() % 5 + 3;
			file << "\t\t\"insulineInjected\": " << CHO * 2 << ",\n";

			file << "\t\t\"breadUnits\": " << CHO << "\n";

			file << "\t},";
		}

		file << "\n]";
	}
}