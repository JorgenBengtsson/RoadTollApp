using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace RoadTollAPI.TestData
{
    public class TestData
    {
        private readonly Random _random = new Random();

        private string[] _firstName = new string[] { "Adam", "Arne", "Bertil", "Borat", "Conrad", "David", "Derek", "Erik", "Ernst", "Fredrik", "Folke", "Göran", "Gunnar", "Håkan", "Harald", "Ivar", "Inge", "Jörgen", "Johan", "Kalle", "Kurt", "Lars", "Ludvik", "Martin", "Molle" };
        private string[] _lastName = new string[] { "Andersson", "Bertilsson", "Eriksson", "Fredriksson", "Göransson", "Håkasson", "Ingesson", "Josefsson", "Karlsson", "Lindberg", "Martinsson", "Nicklasson" };
        private string _letters = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

        private int _ownerMaxId = 1;
        private int _carMaxId = 1;
        private int _tollMaxId = 1;

        public void insertTestData(MigrationBuilder migrationBuilder)
        {
            // Add Owners
            for (int i = 1; i <= 5; i++)
            {
                migrationBuilder.InsertData(
                    table: "Owners",
                    columns: new[] { "id", "name", "adress", "age" },
                    values: new object[] { _ownerMaxId++, rndName(), "Storgatan " + i, rndNr(65) + 17 });

                // Add one or two Cars per Owner

                var numberOfCars = rndNr(2);

                for (int x = 1; x <= numberOfCars; x++)
                {
                    migrationBuilder.InsertData(
                        table: "Cars",
                        columns: new[] { "id", "regnr", "CarOfOwnerId" },
                        values: new object[] { _carMaxId++, rndRegNr(), _ownerMaxId - 1 });

                    // Add Toll passes for the added car

                    var baseDate = new DateTime(2019, 1, 1);
                    var dayOfYear = 0;

                    do
                    {
                        var passesThisDay = rndNr(10) + 4;
                        var hour = rndNr(3) + 5;

                        for (int y = 0; y < passesThisDay; y++)
                        {
                            migrationBuilder.InsertData(
                                table: "Tolls",
                                columns: new[] { "id", "date", "currentCarId" },
                                values: new object[] { _tollMaxId++, baseDate.AddDays(dayOfYear).AddHours(hour), _carMaxId - 1 });

                            hour = hour + rndNr(4) + 1;
                            if (hour > 23) break;
                        }

                        var daysPassedSinceLast = rndNr(4);
                        dayOfYear = dayOfYear + daysPassedSinceLast;
                    } while (dayOfYear < 365);
                }

            }
        }

        private string rndRegNr()
        {
            var output = rndLetter().ToString() + rndLetter().ToString() + rndLetter().ToString() + rndNr(9).ToString() + rndNr(9).ToString() + rndNr(9).ToString();
            return output;
        }

        private string rndName()
        {
            return _firstName[rndNr(_firstName.Length) - 1] + " " + _lastName[rndNr(_lastName.Length) - 1];
        }

        private char rndLetter()
        {
            return _letters[rndNr(_letters.Length) - 1];
        }

        private int rndNr(int max)
        {
            return _random.Next(1, max);
        }

        private class Car
        {
            public int id { get; set; }
            public string regNr { get; set; }
        }
    }
}
