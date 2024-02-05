using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Seed
    {
        private readonly PostgresContext dataContext;
        public Seed(PostgresContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                var Users = new List<User>()
                {
                    new User()
                    {   NameUser ="Артем1",
                        User_tasks = new List<User_tasks>()
                        {
                            new User_tasks()
                            {
                                Task = new Models.Task
                                {  Description = "Купить молоко",
                                   Status_Tasks = new List<Status_Tasks>()
                                   {
                                       new Status_Tasks()
                                       {
                                           Status = new Status
                                           {
                                               Name = "Завершенные"
                                           }
                                       }
                                   }

                                }




                            },
                            new User_tasks()
                            {
                                Task = new Models.Task
                                {  Description = "Полить цветы",
                                   Status_Tasks = new List<Status_Tasks>()
                                   {
                                       new Status_Tasks()
                                       {
                                           Status = new Status
                                           {
                                               Name = "В процессе"
                                           }
                                       }
                                   }

                                }




                            },


                        }, User_Targets = new List<User_targets>()
                        {
                            new User_targets()
                            {
                                Target = new Target
                                {  Description = "Выучить испанский",
                                   Status_targets = new List<Status_targets>()
                                   {
                                       new Status_targets()
                                       {
                                           Status = new Status
                                           {
                                               Name = "Завершенные"
                                           }
                                       }
                                   }

                                }




                            },
                            new User_targets()
                            {
                                Target = new Target
                                {  Description = "Научиться танцевать хип-хоп",
                                   Status_targets = new List<Status_targets>()
                                   {
                                       new Status_targets()
                                       {
                                           Status = new Status
                                           {
                                               Name = "В процессе"
                                           }
                                       }
                                   }

                                }




                            },


                        },  User_contacts = new List<User_contacts>()
                        {
                            new User_contacts()
                            {
                                Contact = new Contact
                                {  Description = "Данил 69530-263"


                                }




                            }, new User_contacts()
                            {
                                Contact = new Contact
                                {  Description = "Иван 131962854"


                                }




                            },





                            },





                    },new User()
                    {   NameUser ="Артем2",
                        User_tasks = new List<User_tasks>()
                        {
                            new User_tasks()
                            {
                                Task = new Models.Task
                                {  Description = "Купить хлеб",
                                   Status_Tasks = new List<Status_Tasks>()
                                   {
                                       new Status_Tasks()
                                       {
                                           Status = new Status
                                           {
                                               Name = "Завершенные"
                                           }
                                       }
                                   }

                                }




                            },
                            new User_tasks()
                            {
                                Task = new Models.Task
                                {  Description = "Погулять с собакой",
                                   Status_Tasks = new List<Status_Tasks>()
                                   {
                                       new Status_Tasks()
                                       {
                                           Status = new Status
                                           {
                                               Name = "В процессе"
                                           }
                                       }
                                   }

                                }




                            },


                        }, User_Targets = new List<User_targets>()
                        {
                            new User_targets()
                            {
                                Target = new Target
                                {  Description = "Выучить китайский",
                                   Status_targets = new List<Status_targets>()
                                   {
                                       new Status_targets()
                                       {
                                           Status = new Status
                                           {
                                               Name = "Завершенные"
                                           }
                                       }
                                   }

                                }




                            },
                            new User_targets()
                            {
                                Target = new Target
                                {  Description = "Сдать ЕГЭ на 300 баллов",
                                   Status_targets = new List<Status_targets>()
                                   {
                                       new Status_targets()
                                       {
                                           Status = new Status
                                           {
                                               Name = "В процессе"
                                           }
                                       }
                                   }

                                }




                            },


                        },  User_contacts = new List<User_contacts>()
                        {
                            new User_contacts()
                            {
                                Contact = new Contact
                                {  Description = "Настя 69530-263"


                                }




                            }, new User_contacts()
                            {
                                Contact = new Contact
                                {  Description = "Анна 131962854"


                                }




                            },





                            },





                    },


                };
                dataContext.Users.AddRange(Users);
                dataContext.SaveChanges();
            }
        }
    }
}

