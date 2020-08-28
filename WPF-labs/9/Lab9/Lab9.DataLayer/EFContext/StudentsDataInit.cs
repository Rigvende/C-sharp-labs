using Lab9.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Lab9.DataLayer.EFContext
{
    class StudentsDataInit : CreateDatabaseIfNotExists<StudentsDataContext>
    {
        protected override void Seed(StudentsDataContext context)
        {
            context.Groups.AddRange(new Group[] {
                new Group { Price=3000, StartDate=new DateTime(2020, 09, 01), EndDate=new DateTime(2022, 06, 25),
                            Specialty="Веб-разработка", Students=new List<Student>
                            {
                                new Student { IndividualPrice=3000, DateOfBirth=new DateTime(1999, 10, 01),
                                              Name="Томас Андерсон", Photo="2.jpg" },
                                new Student { IndividualPrice=2400, DateOfBirth=new DateTime(1981, 03, 05),
                                              Name="Абрам Хакерман", Photo="1.jpg" }
                            }
                },
                new Group { Price=2500, StartDate=new DateTime(2020, 09, 01), EndDate=new DateTime(2022, 06, 25), 
                            Specialty="Системное администрирование", Students=new List<Student>
                            {
                                new Student { IndividualPrice=2500, DateOfBirth=new DateTime(1996, 06, 14),
                                              Name="Джо Макмиллан", Photo="3.jpg" },
                                new Student { IndividualPrice=2000, DateOfBirth=new DateTime(1989, 05, 01),
                                              Name="Марианна Патрусова", Photo="4.jpg" }
                            }
                }
            });
            context.SaveChanges();
        }

    }

}