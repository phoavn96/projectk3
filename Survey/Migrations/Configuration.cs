namespace Survey.Migrations
{
    using Survey.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM [AllSurveys]");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('AllSurveys', RESEED, 0)");
            string CreateDate = "22-03-2021 07:50:00:AM";
            string UpdateDate = "22-06-2022 07:50:00:AM";
            context.FAQs.AddOrUpdate(x => x.FAQId,
                 new FAQ()
                 {  
                     FAQId = 1,
                     Title = "How to register for the survey? How to participate in the survey?",
                     Name = "How to register for the survey? How to participate in the survey?",    
                     Description = "Click Button Login/Register in the home page ."
                     },
                     new FAQ()
                     {
                         FAQId = 1,
                         Title = "How to participate in the survey?",
                         Name = "How to participate in the survey?",
                         Description = "Point to 'Survey' on the menu bar, there will appear a list of survey, find a survey you can join and answer the question."
                     },
                      new FAQ()
                      {
                          FAQId = 2,
                          Title = "hat if there are some arrears in participating the survey?",
                          Name = "What if there are some arrears in participating the survey?",
                          Description = "This is because you need the admin to validate your account before you can survey the contest"
                      },
                       new FAQ()
                       {
                           FAQId = 3,
                           Title = "Will there be any benefit if participated in the survey?",
                           Name = "Will there be any benefit if participated in the survey?",
                           Description = "You will learn more about the environmental damage, and figure out how to fix it"
                       },
                       new FAQ()
                       {
                           FAQId = 4,
                           Title = "Why I am unable to participate in the survey?",
                           Name = "Why I am unable to participate in the survey?",
                           Description = "because you have answered all of them, or maybe the survey is out of date or not taking place yet,Or maybe you haven't signed up for an account yet"
                       },
                         new FAQ()
                         {
                             FAQId = 5,
                             Title = "Why my registration request is not accepted?",
                             Name = "Why my registration request is not accepted?",
                             Description = "Maybe you have to wait for the approval of the administrator, or you did something wrong please contact support"
                         },
                         new FAQ()
                         {
                             FAQId = 6,
                             Title = "What if it gives error, after participating in the entire survey, and clicked on the submit button at the last for submitting the survey?",
                             Name = "What if it gives error, after participating in the entire survey, and clicked on the submit button at the last for submitting the survey?",
                             Description = "If it has an error please report it back to us in the support section"
                         }


                 );
            context.Supports.AddOrUpdate(x => x.Id,
                new Support
                {
                        Id= 1,
                        Name  = "Trong Phu",
                        Description = "Web Design Engineer",
                        Email ="phuqn10x@icloud.com",
                        Mobile = "0347882743"
                },
                  new Support
                  {
                      Id =2 ,
                      Name = "Xuan Phuc",
                      Description = "Web Design Engineer",
                      Email = "xuanphuc123@icloud.com",
                      Mobile = "0347293490"
                  }

                );
              context.Surveys.AddOrUpdate(x => x.SurveyId,
                   new AllSurvey()
                   {
                       SurveyId = 0,
                       Title = "Water Use and Conservation Survey",
                       Description = "In this theme, students will think about the way they use water on a daily basis and the impact of those habits on the environment. They will investigate the source of water they use in their community and consider different ways in which it is used.  They will think critically about using bottled water, and explore methods of conserving water as a useful resource both inside and outside.  ",
                       Status = SurveyStatus.DONE,
                       CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                       UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),

                   },
                    new AllSurvey()
                    {
                        SurveyId = 1,
                        Title = "Litter",
                        Description = "In this theme, students will explore the impact that different kinds of household waste have on the environment and investigate solutions for reduction and disposal. They will explore and assess ways of disposing of unwanted electronic devices and discuss what to do with old batteries. They will investigate solutions to manage wastewater and think critically about solutions to reduce plastic bag waste.",
                        Status = SurveyStatus.HAPPENNING,
                        CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                        UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),

                    },
                     new AllSurvey()
                     {
                         SurveyId = 2,
                         Title = "Forest Fires ",
                         Description = "The goal of this survey is to understand student attitudes toward the causes and containment methods that may be used to minimize the damage from  fires while understanding the level of wildfire awareness, personal impact, and willingness to help fire prevention or firefighting measures.",
                         Status = SurveyStatus.HAPPENNING,
                         CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                         UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),

                     },
                      new AllSurvey()
                      {
                          SurveyId = 3,
                          Title = "Water pollution",
                          Description = "The goal of this survey is to find out student attitudes towards the causes and prevention methods that can be used to prevent water pollution.",
                          Status = SurveyStatus.HAPPENNING,
                          CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                          UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                      },
                       new AllSurvey()
                       {
                           SurveyId = 4,
                           Title = "Power Saving",
                           Description = "The goal of this survey is to find out student attitudes towards the causes and prevention methods that can be used to prevent Power Saving.",
                           Status = SurveyStatus.HAPPENNING,
                           CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                           UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                       },
                        new AllSurvey()
                        {
                            SurveyId = 5,
                            Title = "Land Pollution",
                            Description = "The goal of this survey is to find out student attitudes towards the causes and prevention methods that can be used to prevent Land Pollution.",
                            Status = SurveyStatus.HAPPENNING,
                            CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                            UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                        }

             
           
                );
            context.Questions.AddOrUpdate(x => x.Id,
                   //Survey 1
                   new Question()
                   {
                       Id = 1,
                       SurveyId = 0,
                       Title = "Question 1",
                       Description = "How many individuals live in your place?",
                       Type = 1,
                   },
                 new Question()
                 {
                     Id = 2,
                     SurveyId = 0,
                     Title = "Question 2",
                     Description = "what is your current living situation?",
                     Type = 3,
                 },

                 new Question()
                 {
                     Id = 3,
                     SurveyId = 0,
                     Title = "Question 3",
                     Description = "Do you pay the water bill?",
                     Type = 0,
                 },
                 new Question()
                 {
                     Id = 4,
                     SurveyId = 0,
                     Title = "Question 4",
                     Description = "Do you have a well or any source of culinary (drinking) water other than city water?",
                     Type = 0,
                 },
                  new Question()
                  {
                      Id = 5,
                      SurveyId = 0,
                      Title = "Question 5",
                      Description = "Compared to the average person, do you think you use:",
                      Type = 1,
                  },
                   new Question()
                   {
                       Id = 6,
                       SurveyId = 0,
                       Title = "Question 6",
                       Description = "Approximately how much do you pay each month, on average, for water?",
                       Type = 1,
                   },
                    new Question()
                    {
                        Id = 7,
                        SurveyId = 0,
                        Title = "Question 7",
                        Description = "Do you know about how much you pay for water on a monthly basis in the summer? ",
                        Type = 1,
                    },
                     new Question()
                     {
                         Id = 8,
                         SurveyId = 0,
                         Title = "Question 8",
                         Description = "do you check your water meter regularly to see how much water you have used?",
                         Type = 0,
                     },
                      new Question()
                      {
                          Id = 9,
                          SurveyId = 0,
                          Title = "Question 9",
                          Description = "what is the main use of water in your living situation? ",
                          Type = 3,
                      },
                       new Question()
                       {
                           Id = 10,
                           SurveyId = 0,
                           Title = "Question 10",
                           Description = "do you currently have any water saving solutions already in your home? ",
                           Type = 0,
                       },
                        new Question()
                        {
                            Id = 11,
                            SurveyId = 0,
                            Title = "Question 11",
                            Description = "would you buy a small product for your household which could reduce your water waste?",
                            Type = 0,
                        },
                         new Question()
                         {
                             Id = 12,
                             SurveyId = 0,
                             Title = "Question 12",
                             Description = "what would the product be best used for? (related to question 11) ",
                             Type = 3,
                         },
                         //Survey 2
                         new Question()
                         {
                             Id = 13,
                             SurveyId = 1,
                             Title = "Question 1",
                             Description = "How old are you?",
                             Type = 1,
                         },
                         new Question()
                         {
                             Id = 14,
                             SurveyId = 1,
                             Title = "Question 2",
                             Description = "Which of these items would you call litter?",
                             Type = 2,
                         },
                         new Question()
                         {
                             Id = 15,
                             SurveyId = 1,
                             Title = "Question 3",
                             Description = "What is your gender?",
                             Type = 1,
                         },
                          new Question()
                          {
                              Id = 16,
                              SurveyId = 1,
                              Title = "Question 4",
                              Description = "How would you describe your school grounds?",
                              Type = 1,
                          },

                          new Question()
                          {
                              Id = 17,
                              SurveyId = 1,
                              Title = "Question 5",
                              Description = "How often do you drop litter?",
                              Type = 1,
                          },
                           new Question()
                           {
                               Id = 18,
                               SurveyId = 1,
                               Title = "Question 6",
                               Description = "If you answered 'Never' to question 5, why don't you drop litter? (Choose one or more)",
                               Type = 2,
                           },
                           new Question()
                           {
                               Id = 19,
                               SurveyId = 1,
                               Title = "Question 7",
                               Description = "If you answered 'Sometimes' or 'Often' to question 5, why do you drop litter? (Choose one or more)",
                               Type = 2,
                           },
                           new Question()
                           {
                               Id = 20,
                               SurveyId = 1,
                               Title = "Question 8",
                               Description = "Having students pick up litter at school stops them from dropping litter themselves. Do you agree or disagree with this statement?",
                               Type = 3,
                           },
                            new Question()
                            {
                                Id = 21,
                                SurveyId = 1,
                                Title = "Question 9",
                                Description = "Who do you think should pick up litter at your school? (Choose one or more)",
                                Type = 3,
                            },
                              //Survey 3
                              new Question()
                              {
                                  Id = 22,
                                  SurveyId = 2,
                                  Title = "Question 1",
                                  Description = "On a scale of 1-5, how knowledgeable are you on the causes of wildfires? - (1 - Not Knowledgeable, 5 - Expert)",
                                  Type = 1,
                              },
                                new Question()
                                {
                                    Id = 23,
                                    SurveyId = 2,
                                    Title = "Question 2",
                                    Description = "In the past year, how much risk of danger have wildfires placed on you, your home, or your place of business?",
                                    Type = 1,

                                },
                                new Question()
                                {
                                    Id = 24,
                                    SurveyId = 2,
                                    Title = "Question 3",
                                    Description = " Who has the responsibility to prevent wildfires? Check all that apply.",
                                    Type = 2,


                                },
                                 new Question()
                                 {
                                     Id = 25,
                                     SurveyId = 2,
                                     Title = "Question 4",
                                     Description = "How do you think the fire season has changed along the West Coast or in the Rocky Mountains over the past decade? Check all that apply. ",
                                     Type = 2,


                                 },

                                     new Question()
                                     {
                                         Id = 26,
                                         SurveyId = 2,
                                         Title = "Question 5",
                                         Description = "What do you think are the greatest factors contributing to wildfire outbreaks? Check all that apply. ",
                                         Type = 2,


                                     },
                                      new Question()
                                      {
                                          Id = 27,
                                          SurveyId = 2,
                                          Title = "Question 6",
                                          Description = "Which of the following changes do you think would help fight wildfires? Check all that apply.  ",
                                          Type = 2,


                                      },
                                       new Question()
                                       {
                                           Id = 28,
                                           SurveyId = 2,
                                           Title = "Question 7",
                                           Description = "Have there been any recent education programs in your county or state for  teaching fire prevention or firefighting methods?  ",
                                           Type = 0,


                                       },
                                         new Question()
                                         {
                                             Id = 29,
                                             SurveyId = 2,
                                             Title = "Question 8",
                                             Description = "Have you personally seen a wildfire? Select all that applies.",
                                             Type = 2,


                                         },
                                           new Question()
                                           {
                                               Id = 30,
                                               SurveyId = 2,
                                               Title = "Question 9",
                                               Description = "Are you currently prepared to evacuate a wildfire?",
                                               Type = 1,


                                           },
                                              new Question()
                                              {
                                                  Id = 31,
                                                  SurveyId = 2,
                                                  Title = "Question 10",
                                                  Description = "Do you or a family member live in a state that has been affected by wildfire smoke that has caused the air quality index to meet or exceed unhealthy conditions this year?",
                                                  Type = 0,


                                              },
                                              //survey 4
                                              new Question()
                                              {
                                                  Id = 32,
                                                  SurveyId = 3,
                                                  Title = "Question 1",
                                                  Description = "On a scale of 1 to 10, 1 being not important and 10 being globally life threatening, how bad do you think water pollution is?",
                                                  Type = 2,


                                              },
                                              new Question()
                                              {
                                                  Id = 33,
                                                  SurveyId = 3,
                                                  Title = "Question 2",
                                                  Description = "How much of an effort do you think humans put in to stop water pollution?",
                                                  Type = 4,


                                              },
                                              new Question()
                                              {
                                                  Id = 34,
                                                  SurveyId = 3,
                                                  Title = "Question 3",
                                                  Description = "How badly do you think that you pollute?",
                                                  Type = 1,


                                              },
                                               new Question()
                                               {
                                                   Id = 35,
                                                   SurveyId = 3,
                                                   Title = "Question 4",
                                                   Description = "If you could work for fifteen days, 7 hours a day digging with no pay, and all your efforts helped people get water, would you do it?",
                                                   Type = 0,


                                               },
                                                 new Question()
                                                 {
                                                     Id = 36,
                                                     SurveyId = 3,
                                                     Title = "Question 5",
                                                     Description = "If you were dying of thirst would you be able to think strait?",
                                                     Type = 0,
                                                 },
                                                    new Question()
                                                    {
                                                        Id = 37,
                                                        SurveyId = 3,
                                                        Title = "Question 6",
                                                        Description = "Have you ever tried to stop water pollution? If so, please explain what you did.",
                                                        Type = 4,
                                                    },
                                                      new Question()
                                                      {
                                                          Id = 38,
                                                          SurveyId = 3,
                                                          Title = "Question 7",
                                                          Description = "Have you ever been effected by water pollution?",
                                                          Type = 0,
                                                      },
                                                        new Question()
                                                        {
                                                            Id = 39,
                                                            SurveyId = 3,
                                                            Title = "Question 8",
                                                            Description = "What do you think should be done to stop water pollution?",
                                                            Type = 4,
                                                        },
                                                         new Question()
                                                         {
                                                             Id = 40,
                                                             SurveyId = 3,
                                                             Title = "Question 9",
                                                             Description = "What do you think is the worst type of water pollution",
                                                             Type = 3,
                                                         },
                                                         new Question()
                                                         {
                                                             Id = 41,
                                                             SurveyId = 3,
                                                             Title = "Question 10",
                                                             Description = " on a scale of 1-20, how bad do you water pollution affects sickness",
                                                             Type = 1,
                                                         },
                                                          //5
                                                          new Question()
                                                          {
                                                              Id = 42,
                                                              SurveyId = 4,
                                                              Title = "Question 1",
                                                              Description = "How much thought do you give to saving energy in your home?",
                                                              Type = 1,
                                                          },
                                                           new Question()
                                                           {
                                                               Id = 43,
                                                               SurveyId = 4,
                                                               Title = "Question 2",
                                                               Description = " How often do you turn the heating down or off when you go out for a few hours or when you go to bed at night?",
                                                               Type = 1,
                                                           },
                                                            new Question()
                                                            {
                                                                Id = 44,
                                                                SurveyId = 4,
                                                                Title = "Question 3",
                                                                Description = "How concerned are you about the expected future price rises in energy?",
                                                                Type = 1,
                                                            },
                                                             new Question()
                                                             {
                                                                 Id = 45,
                                                                 SurveyId = 4,
                                                                 Title = "Question 4",
                                                                 Description = "How concerned are you about climate change?",
                                                                 Type = 1,
                                                             },
                                                              new Question()
                                                              {
                                                                  Id = 46,
                                                                  SurveyId = 4,
                                                                  Title = "Question 5",
                                                                  Description = "Who is your current electricity supplier?",
                                                                  Type = 3,
                                                              },
                                                                new Question()
                                                                {
                                                                    Id = 47,
                                                                    SurveyId = 4,
                                                                    Title = "Question 6",
                                                                    Description = "Who is your current gas supplier?",
                                                                    Type = 3,
                                                                },
                                                                   new Question()
                                                                   {
                                                                       Id = 48,
                                                                       SurveyId = 4,
                                                                       Title = "Question 7",
                                                                       Description = "How do you pay your energy bills?",
                                                                       Type = 3,
                                                                   },
                                                                    new Question()
                                                                    {
                                                                        Id = 49,
                                                                        SurveyId = 4,
                                                                        Title = "Question 8",
                                                                        Description = "Please tick which age groups live in your home (tick all that apply)",
                                                                        Type = 2,
                                                                    },
                                                                      new Question()
                                                                      {
                                                                          Id = 50,
                                                                          SurveyId = 4,
                                                                          Title = "Question 9",
                                                                          Description = "When was your property built?",
                                                                          Type = 1,
                                                                      },
                                                                       //6
                                                                       new Question()
                                                                       {
                                                                           Id = 51,
                                                                           SurveyId = 5,
                                                                           Title = "Question 1",
                                                                           Description = "Have you ever littered before?",
                                                                           Type = 0,
                                                                       },
                                                                         new Question()
                                                                         {
                                                                             Id = 52,
                                                                             SurveyId = 5,
                                                                             Title = "Question 2",
                                                                             Description = "Do you ever use the three R's? (Reuse, Reduce, Recycle)",
                                                                             Type = 1,
                                                                         },
                                                                           new Question()
                                                                           {
                                                                               Id = 53,
                                                                               SurveyId = 5,
                                                                               Title = "Question 3",
                                                                               Description = "Do you know how serious land pollution is?",
                                                                               Type = 0,
                                                                           },
                                                                             new Question()
                                                                             {
                                                                                 Id = 54,
                                                                                 SurveyId = 5,
                                                                                 Title = "Question 4",
                                                                                 Description = "If you could, would you help save the Earth from land pollution?",
                                                                                 Type = 1,
                                                                             },

                                                                              new Question()
                                                                              {
                                                                                  Id = 55,
                                                                                  SurveyId = 5,
                                                                                  Title = "Question 5",
                                                                                  Description = "Do you know anyone who litters?",
                                                                                  Type = 0,
                                                                              },
                                                                               new Question()
                                                                               {
                                                                                   Id = 56,
                                                                                   SurveyId = 5,
                                                                                   Title = "Question 6",
                                                                                   Description = "Do you know how land pollution affects the world?",
                                                                                   Type = 0,
                                                                               },
                                                                                new Question()
                                                                                {
                                                                                    Id = 57,
                                                                                    SurveyId = 5,
                                                                                    Title = "Question 7",
                                                                                    Description = "Do you know how land pollution affects the world?",
                                                                                    Type = 0,
                                                                                },
                                                                                 new Question()
                                                                                 {
                                                                                     Id = 58,
                                                                                     SurveyId = 5,
                                                                                     Title = "Question 8",
                                                                                     Description = "How long have you known about land pollution?",
                                                                                     Type = 1,
                                                                                 },

                                                                                  new Question()
                                                                                  {
                                                                                      Id = 59,
                                                                                      SurveyId = 5,
                                                                                      Title = "Question 9",
                                                                                      Description = "Have you ever tried to reduce land pollution?",
                                                                                      Type = 0,
                                                                                  }


                ); ;
            context.Question_answers.AddOrUpdate(x => x.QuestionAnswerId,
                //Survey 1
                //1
                new QuestionAnswer()
                {
                    QuestionId = 1,
                    QuestionAnswerId = 1,
                    Answer = "1",
                },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 2,
                      Answer = "2",
                  },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 3,
                      Answer = "3",
                  },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 4,
                      Answer = "4",
                  },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 5,
                      Answer = "more than that",
                  },
                    //2
                    new QuestionAnswer()
                    {
                        QuestionId = 2,
                        QuestionAnswerId = 6,
                        Answer = "House",
                    },
                      new QuestionAnswer()
                      {
                          QuestionId = 2,
                          QuestionAnswerId = 7,
                          Answer = "Student Living",
                      },
                        new QuestionAnswer()
                        {
                            QuestionId = 2,
                            QuestionAnswerId = 8,
                            Answer = "flat",
                        },
                        new QuestionAnswer()
                        {
                            QuestionId = 2,
                            QuestionAnswerId = 9,
                            Answer = "Other",
                        },
                             //3
                             new QuestionAnswer()
                             {
                                 QuestionId = 3,
                                 QuestionAnswerId = 10,
                                 Answer = "Yes",
                             },
                              new QuestionAnswer()
                              {
                                  QuestionId = 3,
                                  QuestionAnswerId = 11,
                                  Answer = "No",
                              },
                                    //4
                                    new QuestionAnswer()
                                    {
                                        QuestionId = 4,
                                        QuestionAnswerId = 12,
                                        Answer = "Yes",
                                    },
                              new QuestionAnswer()
                              {
                                  QuestionId = 4,
                                  QuestionAnswerId = 13,
                                  Answer = "No",
                              },
                                //5
                                new QuestionAnswer()
                                {
                                    QuestionId = 5,
                                    QuestionAnswerId = 14,
                                    Answer = "More water than average",
                                },
                              new QuestionAnswer()
                              {
                                  QuestionId = 5,
                                  QuestionAnswerId = 15,
                                  Answer = "About average",
                              },
                                new QuestionAnswer()
                                {
                                    QuestionId = 5,
                                    QuestionAnswerId = 16,
                                    Answer = "Less water than average",
                                },
                                 //6
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 6,
                                     QuestionAnswerId = 17,
                                     Answer = "Don't Know",
                                 },
                                new QuestionAnswer()
                                {
                                    QuestionId = 6,
                                    QuestionAnswerId = 18,
                                    Answer = "$0-$30",
                                },
                                new QuestionAnswer()
                                {
                                    QuestionId = 6,
                                    QuestionAnswerId = 19,
                                    Answer = "$30-$50",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 6,
                                     QuestionAnswerId = 20,
                                     Answer = "$50-$100",
                                 },
                                   new QuestionAnswer()
                                   {
                                       QuestionId = 6,
                                       QuestionAnswerId = 21,
                                       Answer = "More than $100",
                                   },
                                      new QuestionAnswer()
                                      {
                                          QuestionId = 6,
                                          QuestionAnswerId = 22,
                                          Answer = "$0-$30",
                                      },
                                       //7
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 7,
                                           QuestionAnswerId = 23,
                                           Answer = "Don't Know",
                                       },
                                new QuestionAnswer()
                                {
                                    QuestionId = 7,
                                    QuestionAnswerId = 24,
                                    Answer = "$30-$50",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 7,
                                     QuestionAnswerId = 25,
                                     Answer = "$50-$100",
                                 },
                                   new QuestionAnswer()
                                   {
                                       QuestionId = 7,
                                       QuestionAnswerId = 26,
                                       Answer = "More than $100",
                                   },

                              //8
                              new QuestionAnswer()
                              {
                                  QuestionId = 8,
                                  QuestionAnswerId = 27,
                                  Answer = "Yes",
                              },
                                new QuestionAnswer()
                                {
                                    QuestionId = 8,
                                    QuestionAnswerId = 28,
                                    Answer = "No",
                                },
                                  new QuestionAnswer()
                                  {
                                      QuestionId = 9,
                                      QuestionAnswerId = 29,
                                      Answer = "cooking",
                                  },
                                new QuestionAnswer()
                                {
                                    QuestionId = 9,
                                    QuestionAnswerId = 30,
                                    Answer = "bathing",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 9,
                                     QuestionAnswerId = 31,
                                     Answer = "washing (washing machine, dishwasher)",
                                 },
                                  new QuestionAnswer()
                                  {
                                      QuestionId = 9,
                                      QuestionAnswerId = 32,
                                      Answer = "drinking",
                                  },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 9,
                                         QuestionAnswerId = 33,
                                         Answer = "Other",
                                     },
                                      new QuestionAnswer()
                                      {
                                          QuestionId = 10,
                                          QuestionAnswerId = 34,
                                          Answer = "Yes",
                                      },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 10,
                                         QuestionAnswerId = 35,
                                         Answer = "No",
                                     },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 11,
                                           QuestionAnswerId = 36,
                                           Answer = "Yes",
                                       },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 11,
                                         QuestionAnswerId = 37,
                                         Answer = "No",
                                     },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 12,
                                           QuestionAnswerId = 38,
                                           Answer = "cooking",
                                       },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 12,
                                         QuestionAnswerId = 39,
                                         Answer = "washing (showering, brushing teeth etc)",
                                     },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 12,
                                           QuestionAnswerId = 40,
                                           Answer = "cleaning (dishes, clothes etc)",

                                       },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 12,
                                           QuestionAnswerId = 41,
                                           Answer = "Other",

                                       },
                                        //Survey 2 
                                        //1
                                        new QuestionAnswer()
                                        {
                                            QuestionId = 13,
                                            QuestionAnswerId = 42,
                                            Answer = "15+",

                                        },
                                         new QuestionAnswer()
                                         {
                                             QuestionId = 13,
                                             QuestionAnswerId = 43,
                                             Answer = "16+",

                                         },
                                          new QuestionAnswer()
                                          {
                                              QuestionId = 13,
                                              QuestionAnswerId = 44,
                                              Answer = "17+",

                                          },
                                           new QuestionAnswer()
                                           {
                                               QuestionId = 13,
                                               QuestionAnswerId = 45,
                                               Answer = "18+",

                                           },
                                            //2
                                            new QuestionAnswer()
                                            {
                                                QuestionId = 14,
                                                QuestionAnswerId = 46,
                                                Answer = "Lunch Wrappers",

                                            },
                                              new QuestionAnswer()
                                              {
                                                  QuestionId = 14,
                                                  QuestionAnswerId = 47,
                                                  Answer = "Cigarette Ends",

                                              },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 14,
                                                    QuestionAnswerId = 48,
                                                    Answer = "Food Scraps",

                                                },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 14,
                                                    QuestionAnswerId = 49,
                                                    Answer = "Fallen Leaves and Twigs",

                                                },
                                                 new QuestionAnswer()
                                                 {
                                                     QuestionId = 14,
                                                     QuestionAnswerId = 50,
                                                     Answer = "Drink Bottles and Cans",

                                                 },
                                                   new QuestionAnswer()
                                                   {
                                                       QuestionId = 14,
                                                       QuestionAnswerId = 51,
                                                       Answer = "An Old Car in a Field",

                                                   },
                                                     //3
                                                     new QuestionAnswer()
                                                     {
                                                         QuestionId = 15,
                                                         QuestionAnswerId = 52,
                                                         Answer = "Female",

                                                     },
                                                       new QuestionAnswer()
                                                       {
                                                           QuestionId = 15,
                                                           QuestionAnswerId = 53,
                                                           Answer = "Male",

                                                       },
                                                        //4
                                                        new QuestionAnswer()
                                                        {
                                                            QuestionId = 16,
                                                            QuestionAnswerId = 54,
                                                            Answer = " Heavily littered",

                                                        },
                                                         new QuestionAnswer()
                                                         {
                                                             QuestionId = 16,
                                                             QuestionAnswerId = 55,
                                                             Answer = "Slightly littered",

                                                         },
                                                          new QuestionAnswer()
                                                          {
                                                              QuestionId = 16,
                                                              QuestionAnswerId = 56,
                                                              Answer = "Not littered",

                                                          },
                                                           //5
                                                           new QuestionAnswer()
                                                           {
                                                               QuestionId = 17,
                                                               QuestionAnswerId = 57,
                                                               Answer = "Often (go to question 7)",

                                                           },
                                                            new QuestionAnswer()
                                                            {
                                                                QuestionId = 17,
                                                                QuestionAnswerId = 58,
                                                                Answer = "Sometimes(go to question 7)",

                                                            },
                                                             new QuestionAnswer()
                                                             {
                                                                 QuestionId = 17,
                                                                 QuestionAnswerId = 59,
                                                                 Answer = "Never(go to question 6)",

                                                             },
                                                               //6
                                                               new QuestionAnswer()
                                                               {
                                                                   QuestionId = 18,
                                                                   QuestionAnswerId = 60,
                                                                   Answer = "I think that litter spoils the appearance of a place.",

                                                               },
                                                               new QuestionAnswer()
                                                               {
                                                                   QuestionId = 18,
                                                                   QuestionAnswerId = 61,
                                                                   Answer = "I am afraid of being caught and punished.",

                                                               },
                                                                new QuestionAnswer()
                                                                {
                                                                    QuestionId = 18,
                                                                    QuestionAnswerId = 62,
                                                                    Answer = "I know it's wrong.",

                                                                },
                                                                  new QuestionAnswer()
                                                                  {
                                                                      QuestionId = 18,
                                                                      QuestionAnswerId = 63,
                                                                      Answer = "I know that animals can be hurt or killed by litter.",

                                                                  },
                                                                   new QuestionAnswer()
                                                                   {
                                                                       QuestionId = 18,
                                                                       QuestionAnswerId = 64,
                                                                       Answer = "I am worried that people will be hurt by litter.",

                                                                   },
                                                                    new QuestionAnswer()
                                                                    {
                                                                        QuestionId = 18,
                                                                        QuestionAnswerId = 65,
                                                                        Answer = "I am worried that it will be washed into rivers, streams, and the ocean.",

                                                                    },
                                                                       //7
                                                                       new QuestionAnswer()
                                                                       {
                                                                           QuestionId = 19,
                                                                           QuestionAnswerId = 66,
                                                                           Answer = "I think that litter spoils the appearance of a place.",

                                                                       },
                                                                         new QuestionAnswer()
                                                                         {
                                                                             QuestionId = 19,
                                                                             QuestionAnswerId = 67,
                                                                             Answer = "I am afraid of being caught and punished.",

                                                                         },
                                                                           new QuestionAnswer()
                                                                           {
                                                                               QuestionId = 19,
                                                                               QuestionAnswerId = 68,
                                                                               Answer = "I know it's wrong.",

                                                                           },
                                                                             new QuestionAnswer()
                                                                             {
                                                                                 QuestionId = 19,
                                                                                 QuestionAnswerId = 69,
                                                                                 Answer = "I know that animals can be hurt or killed by litter.",

                                                                             },
                                                                             new QuestionAnswer()
                                                                             {
                                                                                 QuestionId = 19,
                                                                                 QuestionAnswerId = 70,
                                                                                 Answer = "I am worried that people will be hurt by litter.",

                                                                             },
                                                                             new QuestionAnswer()
                                                                             {
                                                                                 QuestionId = 19,
                                                                                 QuestionAnswerId = 71,
                                                                                 Answer = "I am worried that it will be washed into rivers, streams, and the ocean.",

                                                                             },
                                                                                       //8
                                                                                       new QuestionAnswer()
                                                                                       {
                                                                                           QuestionId = 20,
                                                                                           QuestionAnswerId = 72,
                                                                                           Answer = "Agree",

                                                                                       },
                                                                                          new QuestionAnswer()
                                                                                          {
                                                                                              QuestionId = 20,
                                                                                              QuestionAnswerId = 73,
                                                                                              Answer = "Disagree",

                                                                                          },
                                                                                           new QuestionAnswer()
                                                                                           {
                                                                                               QuestionId = 20,
                                                                                               QuestionAnswerId = 74,
                                                                                               Answer = "Other",

                                                                                           },
                                                                                          //9
                                                                                          new QuestionAnswer()
                                                                                          {
                                                                                              QuestionId = 21,
                                                                                              QuestionAnswerId = 75,
                                                                                              Answer = "Students caught dropping litter ",

                                                                                          },
                                                                                          new QuestionAnswer()
                                                                                          {
                                                                                              QuestionId = 21,
                                                                                              QuestionAnswerId = 76,
                                                                                              Answer = "All students",

                                                                                          },
                                                                                           new QuestionAnswer()
                                                                                           {
                                                                                               QuestionId = 21,
                                                                                               QuestionAnswerId = 77,
                                                                                               Answer = "Teachers",

                                                                                           },
                                                                                            new QuestionAnswer()
                                                                                            {
                                                                                                QuestionId = 21,
                                                                                                QuestionAnswerId = 78,
                                                                                                Answer = "Custodians",

                                                                                            },
                                                                                             new QuestionAnswer()
                                                                                             {
                                                                                                 QuestionId = 21,
                                                                                                 QuestionAnswerId = 79,
                                                                                                 Answer = "Other",

                                                                                             },
                                                                                              //Survey 3     
                                                                                              new QuestionAnswer()
                                                                                              {
                                                                                                  QuestionId = 22,
                                                                                                  QuestionAnswerId = 80,
                                                                                                  Answer = "1",

                                                                                              },
                                                                                              new QuestionAnswer()
                                                                                              {
                                                                                                  QuestionId = 22,
                                                                                                  QuestionAnswerId = 81,
                                                                                                  Answer = "2",

                                                                                              },
                                                                                              new QuestionAnswer()
                                                                                              {
                                                                                                  QuestionId = 22,
                                                                                                  QuestionAnswerId = 82,
                                                                                                  Answer = "3",

                                                                                              },
                                                                                                new QuestionAnswer()
                                                                                                {
                                                                                                    QuestionId = 22,
                                                                                                    QuestionAnswerId = 83,
                                                                                                    Answer = "4",

                                                                                                },
                                                                                                  new QuestionAnswer()
                                                                                                  {
                                                                                                      QuestionId = 22,
                                                                                                      QuestionAnswerId = 84,
                                                                                                      Answer = "5",

                                                                                                  },
                                                                                                    new QuestionAnswer()
                                                                                                    {
                                                                                                        QuestionId = 23,
                                                                                                        QuestionAnswerId = 85,
                                                                                                        Answer = "No Risk",

                                                                                                    },
                                                                                                      new QuestionAnswer()
                                                                                                      {
                                                                                                          QuestionId = 23,
                                                                                                          QuestionAnswerId = 86,
                                                                                                          Answer = "Slight Risk",

                                                                                                      },
                                                                                                       new QuestionAnswer()
                                                                                                       {
                                                                                                           QuestionId = 23,
                                                                                                           QuestionAnswerId = 87,
                                                                                                           Answer = "Moderate Risk",

                                                                                                       },
                                                                                                        new QuestionAnswer()
                                                                                                        {
                                                                                                            QuestionId = 23,
                                                                                                            QuestionAnswerId = 88,
                                                                                                            Answer = "Great Risk",

                                                                                                        },
                                                                                                         new QuestionAnswer()
                                                                                                         {
                                                                                                             QuestionId = 23,
                                                                                                             QuestionAnswerId = 89,
                                                                                                             Answer = "Extreme Risk",

                                                                                                         },
                                                                                                         new QuestionAnswer()
                                                                                                         {
                                                                                                             QuestionId = 24,
                                                                                                             QuestionAnswerId = 90,
                                                                                                             Answer = "The Forest Service",

                                                                                                         },
                                                                                                          new QuestionAnswer()
                                                                                                          {
                                                                                                              QuestionId = 24,
                                                                                                              QuestionAnswerId = 91,
                                                                                                              Answer = "The National Government",

                                                                                                          },
                                                                                                           new QuestionAnswer()
                                                                                                           {
                                                                                                               QuestionId = 24,
                                                                                                               QuestionAnswerId = 92,
                                                                                                               Answer = "The Forest Service",

                                                                                                           },
                                                                                                            new QuestionAnswer()
                                                                                                            {
                                                                                                                QuestionId = 24,
                                                                                                                QuestionAnswerId = 93,
                                                                                                                Answer = "The State Government ",

                                                                                                            },
                                                                                                             new QuestionAnswer()
                                                                                                             {
                                                                                                                 QuestionId = 24,
                                                                                                                 QuestionAnswerId = 94,
                                                                                                                 Answer = "The Public",

                                                                                                             },
                                                                                                              new QuestionAnswer()
                                                                                                              {
                                                                                                                  QuestionId = 24,
                                                                                                                  QuestionAnswerId = 95,
                                                                                                                  Answer = "Private Property Owners",

                                                                                                              },
                                                                                                                 new QuestionAnswer()
                                                                                                                 {
                                                                                                                     QuestionId = 24,
                                                                                                                     QuestionAnswerId = 96,
                                                                                                                     Answer = "Local Fire Departments",

                                                                                                                 },
                                                                                                                  new QuestionAnswer()
                                                                                                                  {
                                                                                                                      QuestionId = 24,
                                                                                                                      QuestionAnswerId = 97,
                                                                                                                      Answer = "State Conservation Department",

                                                                                                                  },
                                                                                                                       new QuestionAnswer()
                                                                                                                       {
                                                                                                                           QuestionId = 25,
                                                                                                                           QuestionAnswerId = 98,
                                                                                                                           Answer = "Longer Fire Season",


                                                                                                                       },
                                                                                                                            new QuestionAnswer()
                                                                                                                            {
                                                                                                                                QuestionId = 25,
                                                                                                                                QuestionAnswerId = 99,
                                                                                                                                Answer = "Greater Number of Wildfires",


                                                                                                                            },
                                                                                                                                 new QuestionAnswer()
                                                                                                                                 {
                                                                                                                                     QuestionId = 25,
                                                                                                                                     QuestionAnswerId = 100,
                                                                                                                                     Answer = "Bigger or More Dangerous Fires",


                                                                                                                                 },
                                                                                                                                  new QuestionAnswer()
                                                                                                                                  {
                                                                                                                                      QuestionId = 25,
                                                                                                                                      QuestionAnswerId = 101,
                                                                                                                                      Answer = "Greater Property Damage",


                                                                                                                                  },
                                                                                                                                   new QuestionAnswer()
                                                                                                                                   {
                                                                                                                                       QuestionId = 25,
                                                                                                                                       QuestionAnswerId = 102,
                                                                                                                                       Answer = "More Media Coverage of Fire Season",


                                                                                                                                   },
                                                                                                                                    new QuestionAnswer()
                                                                                                                                    {
                                                                                                                                        QuestionId = 25,
                                                                                                                                        QuestionAnswerId = 103,
                                                                                                                                        Answer = "No Change In Fire Season",


                                                                                                                                    },
                                                                                                                                     new QuestionAnswer()
                                                                                                                                     {
                                                                                                                                         QuestionId = 25,
                                                                                                                                         QuestionAnswerId = 104,
                                                                                                                                         Answer = "Don't Know/Not Sure",


                                                                                                                                     },

                                                                                                                                         new QuestionAnswer()
                                                                                                                                         {
                                                                                                                                             QuestionId = 26,
                                                                                                                                             QuestionAnswerId = 105,
                                                                                                                                             Answer = "Climate Change",
                                                                                                                                         },
                                                                                                                                           new QuestionAnswer()
                                                                                                                                           {
                                                                                                                                               QuestionId = 26,
                                                                                                                                               QuestionAnswerId = 106,
                                                                                                                                               Answer = "Poor Forest Management",
                                                                                                                                           },

                                                                                                                                             new QuestionAnswer()
                                                                                                                                             {
                                                                                                                                                 QuestionId = 26,
                                                                                                                                                 QuestionAnswerId = 107,
                                                                                                                                                 Answer = "Urban Expansion",
                                                                                                                                             },
                                                                                                                                              new QuestionAnswer()
                                                                                                                                              {
                                                                                                                                                  QuestionId = 26,
                                                                                                                                                  QuestionAnswerId = 108,
                                                                                                                                                  Answer = "Drought",
                                                                                                                                              },
                                                                                                                                               new QuestionAnswer()
                                                                                                                                               {
                                                                                                                                                   QuestionId = 26,
                                                                                                                                                   QuestionAnswerId = 109,
                                                                                                                                                   Answer = "High Winds",
                                                                                                                                               },
                                                                                                                                               new QuestionAnswer()
                                                                                                                                               {
                                                                                                                                                   QuestionId = 27,
                                                                                                                                                   QuestionAnswerId = 110,
                                                                                                                                                   Answer = "Increasing Funding to Local Firefighters",
                                                                                                                                               },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 111,
                                                                                                                                                     Answer = "Constructing More Dams and Reservoirs to Build A Ready Supply of Water",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 112,
                                                                                                                                                     Answer = "Taxing Carbon Polluters and Creating Carbon Offsets to Reduce Global Warming",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 113,
                                                                                                                                                     Answer = "Redesigning City Infrastructure to Slow the Spread of Wildfires in Urban Areas",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 114,
                                                                                                                                                     Answer = "Controlled Burning and Removal of Dead Brush and Trees",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 115,
                                                                                                                                                     Answer = "Greater Efforts at Public Education on Fire Safety and Wildfire Prevention",
                                                                                                                                                 },
                                                                                                                                                   new QuestionAnswer()
                                                                                                                                                   {
                                                                                                                                                       QuestionId = 28,
                                                                                                                                                       QuestionAnswerId = 116,
                                                                                                                                                       Answer = "Yes",
                                                                                                                                                   },
                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                     {
                                                                                                                                                         QuestionId = 28,
                                                                                                                                                         QuestionAnswerId = 117,
                                                                                                                                                         Answer = "No",
                                                                                                                                                     },

                                                                                                                                                       new QuestionAnswer()
                                                                                                                                                       {
                                                                                                                                                           QuestionId = 29,
                                                                                                                                                           QuestionAnswerId = 118,
                                                                                                                                                           Answer = "I have seen a wildfire on the news or through media. ",
                                                                                                                                                       },

                                                                                                                                                         new QuestionAnswer()
                                                                                                                                                         {
                                                                                                                                                             QuestionId = 29,
                                                                                                                                                             QuestionAnswerId = 119,
                                                                                                                                                             Answer = "I have seen a red, orange, or yellow glow in the sky from a close wildfire. ",
                                                                                                                                                         },

                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 29,
                                                                                                                                                               QuestionAnswerId = 120,
                                                                                                                                                               Answer = "I have seen wildfire flames in person.",
                                                                                                                                                           },

                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 29,
                                                                                                                                                               QuestionAnswerId = 121,
                                                                                                                                                               Answer = "I have not seen a wildfire. ",
                                                                                                                                                           },

                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 29,
                                                                                                                                                               QuestionAnswerId = 122,
                                                                                                                                                               Answer = "Don't Know/Unsure",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 30,
                                                                                                                                                               QuestionAnswerId = 123,
                                                                                                                                                               Answer = "I am prepared to evacuate.",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 30,
                                                                                                                                                               QuestionAnswerId = 124,
                                                                                                                                                               Answer = "I am somewhat prepared to evacuate.",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 30,
                                                                                                                                                               QuestionAnswerId = 125,
                                                                                                                                                               Answer = "I am not prepared to evacuate.",
                                                                                                                                                           },


                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 31,
                                                                                                                                                               QuestionAnswerId = 126,
                                                                                                                                                               Answer = "Yes",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 31,
                                                                                                                                                               QuestionAnswerId = 127,
                                                                                                                                                               Answer = "No",
                                                                                                                                                           },
                                                                                                                                                            //survey 4
                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                            {
                                                                                                                                                                QuestionId = 32,
                                                                                                                                                                QuestionAnswerId = 128,
                                                                                                                                                                Answer = "1",
                                                                                                                                                            },
                                                                                                                                                              new QuestionAnswer()
                                                                                                                                                              {
                                                                                                                                                                  QuestionId = 32,
                                                                                                                                                                  QuestionAnswerId = 129,
                                                                                                                                                                  Answer = "2",
                                                                                                                                                              },
                                                                                                                                                                new QuestionAnswer()
                                                                                                                                                                {
                                                                                                                                                                    QuestionId = 32,
                                                                                                                                                                    QuestionAnswerId = 130,
                                                                                                                                                                    Answer = "3",
                                                                                                                                                                },
                                                                                                                                                                  new QuestionAnswer()
                                                                                                                                                                  {
                                                                                                                                                                      QuestionId = 32,
                                                                                                                                                                      QuestionAnswerId = 131,
                                                                                                                                                                      Answer = "4",
                                                                                                                                                                  },

                                                                                                                                                                    new QuestionAnswer()
                                                                                                                                                                    {
                                                                                                                                                                        QuestionId = 32,
                                                                                                                                                                        QuestionAnswerId = 132,
                                                                                                                                                                        Answer = "4",
                                                                                                                                                                    },
                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                      {
                                                                                                                                                                          QuestionId = 32,
                                                                                                                                                                          QuestionAnswerId = 133,
                                                                                                                                                                          Answer = "5",
                                                                                                                                                                      },
                                                                                                                                                                        new QuestionAnswer()
                                                                                                                                                                        {
                                                                                                                                                                            QuestionId = 32,
                                                                                                                                                                            QuestionAnswerId = 134,
                                                                                                                                                                            Answer = "6",
                                                                                                                                                                        },
                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                          {
                                                                                                                                                                              QuestionId = 32,
                                                                                                                                                                              QuestionAnswerId = 135,
                                                                                                                                                                              Answer = "7",
                                                                                                                                                                          },
                                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                                            {
                                                                                                                                                                                QuestionId = 32,
                                                                                                                                                                                QuestionAnswerId = 136,
                                                                                                                                                                                Answer = "8",
                                                                                                                                                                            },
                                                                                                                                                                              new QuestionAnswer()
                                                                                                                                                                              {
                                                                                                                                                                                  QuestionId = 32,
                                                                                                                                                                                  QuestionAnswerId = 137,
                                                                                                                                                                                  Answer = "9",
                                                                                                                                                                              },
                                                                                                                                                                              new QuestionAnswer()
                                                                                                                                                                              {
                                                                                                                                                                                  QuestionId = 32,
                                                                                                                                                                                  QuestionAnswerId = 138,
                                                                                                                                                                                  Answer = "10",
                                                                                                                                                                              },

                                                                                                                                                                                //2
                                                                                                                                                                                new QuestionAnswer()
                                                                                                                                                                                {
                                                                                                                                                                                    QuestionId = 33,
                                                                                                                                                                                    QuestionAnswerId = 139,
                                                                                                                                                                                    Answer = "Essay",
                                                                                                                                                                                },
                                                                                                                                                                                //3
                                                                                                                                                                                new QuestionAnswer()
                                                                                                                                                                                {
                                                                                                                                                                                    QuestionId = 34,
                                                                                                                                                                                    QuestionAnswerId = 140,
                                                                                                                                                                                    Answer = "None",
                                                                                                                                                                                },
                                                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                                                 {
                                                                                                                                                                                     QuestionId = 34,
                                                                                                                                                                                     QuestionAnswerId = 141,
                                                                                                                                                                                     Answer = "Not too bad",
                                                                                                                                                                                 },
                                                                                                                                                                                  new QuestionAnswer()
                                                                                                                                                                                  {
                                                                                                                                                                                      QuestionId = 34,
                                                                                                                                                                                      QuestionAnswerId = 142,
                                                                                                                                                                                      Answer = "Decently",
                                                                                                                                                                                  },
                                                                                                                                                                                    new QuestionAnswer()
                                                                                                                                                                                    {
                                                                                                                                                                                        QuestionId = 34,
                                                                                                                                                                                        QuestionAnswerId = 143,
                                                                                                                                                                                        Answer = "Badly",
                                                                                                                                                                                    },

                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                     {
                                                                                                                                                                                         QuestionId = 34,
                                                                                                                                                                                         QuestionAnswerId = 144,
                                                                                                                                                                                         Answer = "Very Badly",
                                                                                                                                                                                     },
                                                                                                                                                                                       //4
                                                                                                                                                                                       new QuestionAnswer()
                                                                                                                                                                                       {
                                                                                                                                                                                           QuestionId = 35,
                                                                                                                                                                                           QuestionAnswerId = 145,
                                                                                                                                                                                           Answer = "Yes",
                                                                                                                                                                                       },
                                                                                                                                                                                        new QuestionAnswer()
                                                                                                                                                                                        {
                                                                                                                                                                                            QuestionId = 35,
                                                                                                                                                                                            QuestionAnswerId = 146,
                                                                                                                                                                                            Answer = "No",
                                                                                                                                                                                        },
                                                                                                                                                                                          //5
                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                          {
                                                                                                                                                                                              QuestionId = 36,
                                                                                                                                                                                              QuestionAnswerId = 147,
                                                                                                                                                                                              Answer = "Yes",
                                                                                                                                                                                          },
                                                                                                                                                                                        new QuestionAnswer()
                                                                                                                                                                                        {
                                                                                                                                                                                            QuestionId = 36,
                                                                                                                                                                                            QuestionAnswerId = 148,
                                                                                                                                                                                            Answer = "No",
                                                                                                                                                                                        },
                                                                                                                                                                                         //6
                                                                                                                                                                                         new QuestionAnswer()
                                                                                                                                                                                         {
                                                                                                                                                                                             QuestionId = 37,
                                                                                                                                                                                             QuestionAnswerId = 149,
                                                                                                                                                                                             Answer = "Essay",
                                                                                                                                                                                         },
                                                                                                                                                                                          //7
                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                          {
                                                                                                                                                                                              QuestionId = 38,
                                                                                                                                                                                              QuestionAnswerId = 150,
                                                                                                                                                                                              Answer = "Yes",
                                                                                                                                                                                          },
                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                           {
                                                                                                                                                                                               QuestionId = 38,
                                                                                                                                                                                               QuestionAnswerId = 151,
                                                                                                                                                                                               Answer = "No",
                                                                                                                                                                                           },
                                                                                                                                                                                           //9
                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                           {
                                                                                                                                                                                               QuestionId = 39,
                                                                                                                                                                                               QuestionAnswerId = 152,
                                                                                                                                                                                               Answer = "Essay",
                                                                                                                                                                                           },
                                                                                                                                                                                             //10
                                                                                                                                                                                             new QuestionAnswer()
                                                                                                                                                                                             {
                                                                                                                                                                                                 QuestionId = 40,
                                                                                                                                                                                                 QuestionAnswerId = 153,
                                                                                                                                                                                                 Answer = "Air pollution",
                                                                                                                                                                                             },
                                                                                                                                                                                              new QuestionAnswer()
                                                                                                                                                                                              {
                                                                                                                                                                                                  QuestionId = 40,
                                                                                                                                                                                                  QuestionAnswerId = 154,
                                                                                                                                                                                                  Answer = "Water pollution",
                                                                                                                                                                                              },
                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                               {
                                                                                                                                                                                                   QuestionId = 40,
                                                                                                                                                                                                   QuestionAnswerId = 155,
                                                                                                                                                                                                   Answer = "Taco bell waste",
                                                                                                                                                                                               },
                                                                                                                                                                                                new QuestionAnswer()
                                                                                                                                                                                                {
                                                                                                                                                                                                    QuestionId = 40,
                                                                                                                                                                                                    QuestionAnswerId = 156,
                                                                                                                                                                                                    Answer = "Ground pollution",
                                                                                                                                                                                                },
                                                                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                                                                 {
                                                                                                                                                                                                     QuestionId = 40,
                                                                                                                                                                                                     QuestionAnswerId = 157,
                                                                                                                                                                                                     Answer = "ALL",
                                                                                                                                                                                                 },
                                                                                                                                                                                                  new QuestionAnswer()
                                                                                                                                                                                                  {
                                                                                                                                                                                                      QuestionId = 40,
                                                                                                                                                                                                      QuestionAnswerId = 158,
                                                                                                                                                                                                      Answer = "Other",
                                                                                                                                                                                                  },
                                                                                                                                                                                                    //10
                                                                                                                                                                                                    new QuestionAnswer()
                                                                                                                                                                                                    {
                                                                                                                                                                                                        QuestionId = 41,
                                                                                                                                                                                                        QuestionAnswerId = 159,
                                                                                                                                                                                                        Answer = "1",
                                                                                                                                                                                                    },
                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                      {
                                                                                                                                                                                                          QuestionId = 41,
                                                                                                                                                                                                          QuestionAnswerId = 160,
                                                                                                                                                                                                          Answer = "2",
                                                                                                                                                                                                      },
                                                                                                                                                                                                        new QuestionAnswer()
                                                                                                                                                                                                        {
                                                                                                                                                                                                            QuestionId = 41,
                                                                                                                                                                                                            QuestionAnswerId = 161,
                                                                                                                                                                                                            Answer = "3",
                                                                                                                                                                                                        },
                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                          {
                                                                                                                                                                                                              QuestionId = 41,
                                                                                                                                                                                                              QuestionAnswerId = 162,
                                                                                                                                                                                                              Answer = "4",
                                                                                                                                                                                                          },
                                                                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                                                                            {
                                                                                                                                                                                                                QuestionId = 41,
                                                                                                                                                                                                                QuestionAnswerId = 163,
                                                                                                                                                                                                                Answer = "5",
                                                                                                                                                                                                            },
                                                                                                                                                                                                              new QuestionAnswer()
                                                                                                                                                                                                              {
                                                                                                                                                                                                                  QuestionId = 41,
                                                                                                                                                                                                                  QuestionAnswerId = 164,
                                                                                                                                                                                                                  Answer = "6",
                                                                                                                                                                                                              },
                                                                                                                                                                                                                new QuestionAnswer()
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    QuestionId = 41,
                                                                                                                                                                                                                    QuestionAnswerId = 165,
                                                                                                                                                                                                                    Answer = "7",
                                                                                                                                                                                                                },
                                                                                                                                                                                                                  new QuestionAnswer()
                                                                                                                                                                                                                  {
                                                                                                                                                                                                                      QuestionId = 41,
                                                                                                                                                                                                                      QuestionAnswerId = 166,
                                                                                                                                                                                                                      Answer = "8",
                                                                                                                                                                                                                  },
                                                                                                                                                                                                                    new QuestionAnswer()
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        QuestionId = 41,
                                                                                                                                                                                                                        QuestionAnswerId = 167,
                                                                                                                                                                                                                        Answer = "9",
                                                                                                                                                                                                                    },
                                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                                      {
                                                                                                                                                                                                                          QuestionId = 41,
                                                                                                                                                                                                                          QuestionAnswerId = 168,
                                                                                                                                                                                                                          Answer = "10",
                                                                                                                                                                                                                      },
                                                                                                                                                                                                                        //survey 5
                                                                                                                                                                                                                        new QuestionAnswer()
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            QuestionId = 42,
                                                                                                                                                                                                                            QuestionAnswerId = 169,
                                                                                                                                                                                                                            Answer = "A lot",
                                                                                                                                                                                                                        },
                                                                                                                                                                                                                         new QuestionAnswer()
                                                                                                                                                                                                                         {
                                                                                                                                                                                                                             QuestionId = 42,
                                                                                                                                                                                                                             QuestionAnswerId = 170,
                                                                                                                                                                                                                             Answer = "A fair amount",
                                                                                                                                                                                                                         },
                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                          {
                                                                                                                                                                                                                              QuestionId = 42,
                                                                                                                                                                                                                              QuestionAnswerId = 171,
                                                                                                                                                                                                                              Answer = "Not very much",
                                                                                                                                                                                                                          },
                                                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                                                           {
                                                                                                                                                                                                                               QuestionId = 42,
                                                                                                                                                                                                                               QuestionAnswerId = 172,
                                                                                                                                                                                                                               Answer = "None at all",
                                                                                                                                                                                                                           },
                                                                                                                                                                                                                            //2
                                                                                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                QuestionId = 43,
                                                                                                                                                                                                                                QuestionAnswerId = 173,
                                                                                                                                                                                                                                Answer = "Almost always",
                                                                                                                                                                                                                            },
                                                                                                                                                                                                                             new QuestionAnswer()
                                                                                                                                                                                                                             {
                                                                                                                                                                                                                                 QuestionId = 43,
                                                                                                                                                                                                                                 QuestionAnswerId = 174,
                                                                                                                                                                                                                                 Answer = "Very often",
                                                                                                                                                                                                                             },
                                                                                                                                                                                                                              new QuestionAnswer()
                                                                                                                                                                                                                              {
                                                                                                                                                                                                                                  QuestionId = 43,
                                                                                                                                                                                                                                  QuestionAnswerId = 175,
                                                                                                                                                                                                                                  Answer = "Not very often",
                                                                                                                                                                                                                              },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 43,
                                                                                                                                                                                                                                   QuestionAnswerId = 176,
                                                                                                                                                                                                                                   Answer = "Never",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               //3
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 44,
                                                                                                                                                                                                                                   QuestionAnswerId = 177,
                                                                                                                                                                                                                                   Answer = "A lot",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 44,
                                                                                                                                                                                                                                   QuestionAnswerId = 178,
                                                                                                                                                                                                                                   Answer = "A fair amount",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 44,
                                                                                                                                                                                                                                   QuestionAnswerId = 179,
                                                                                                                                                                                                                                   Answer = "Not very much",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 44,
                                                                                                                                                                                                                                   QuestionAnswerId = 180,
                                                                                                                                                                                                                                   Answer = "Not at all",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               //4
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 45,
                                                                                                                                                                                                                                   QuestionAnswerId = 181,
                                                                                                                                                                                                                                   Answer = "A lot",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 45,
                                                                                                                                                                                                                                   QuestionAnswerId = 182,
                                                                                                                                                                                                                                   Answer = "A fair amount",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 45,
                                                                                                                                                                                                                                   QuestionAnswerId = 183,
                                                                                                                                                                                                                                   Answer = "Not very much",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 45,
                                                                                                                                                                                                                                   QuestionAnswerId = 184,
                                                                                                                                                                                                                                   Answer = "Not at all",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               //5
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 185,
                                                                                                                                                                                                                                   Answer = "EDF Energy",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 186,
                                                                                                                                                                                                                                   Answer = "NPower",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 188,
                                                                                                                                                                                                                                   Answer = "Southern Electric",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 189,
                                                                                                                                                                                                                                   Answer = "E.On",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 190,
                                                                                                                                                                                                                                   Answer = "Scottish Power",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 191,
                                                                                                                                                                                                                                   Answer = "British Gas",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 192,
                                                                                                                                                                                                                                   Answer = "Utility Warehouse",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 193,
                                                                                                                                                                                                                                   Answer = "First Utility",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 46,
                                                                                                                                                                                                                                   QuestionAnswerId = 194,
                                                                                                                                                                                                                                   Answer = "Other",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               //7
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 195,
                                                                                                                                                                                                                                   Answer = "EDF Energy",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 196,
                                                                                                                                                                                                                                   Answer = "NPower",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 197,
                                                                                                                                                                                                                                   Answer = "Southern Electric",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 198,
                                                                                                                                                                                                                                   Answer = "E.On",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 199,
                                                                                                                                                                                                                                   Answer = "Scottish Power",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 200,
                                                                                                                                                                                                                                   Answer = "British Gas",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 201,
                                                                                                                                                                                                                                   Answer = "Utility Warehouse",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 202,
                                                                                                                                                                                                                                   Answer = "First Utility",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                   QuestionId = 47,
                                                                                                                                                                                                                                   QuestionAnswerId = 203,
                                                                                                                                                                                                                                   Answer = "Other",
                                                                                                                                                                                                                               },
                                                                                                                                                                                                                                //8
                                                                                                                                                                                                                                new QuestionAnswer()
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    QuestionId = 48,
                                                                                                                                                                                                                                    QuestionAnswerId = 204,
                                                                                                                                                                                                                                    Answer = "Monthly bill",
                                                                                                                                                                                                                                },
                                                                                                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                                                                                                 {
                                                                                                                                                                                                                                     QuestionId = 48,
                                                                                                                                                                                                                                     QuestionAnswerId = 205,
                                                                                                                                                                                                                                     Answer = "Included in my rent",
                                                                                                                                                                                                                                 },
                                                                                                                                                                                                                                  new QuestionAnswer()
                                                                                                                                                                                                                                  {
                                                                                                                                                                                                                                      QuestionId = 48,
                                                                                                                                                                                                                                      QuestionAnswerId = 206,
                                                                                                                                                                                                                                      Answer = "Quarterly bill",
                                                                                                                                                                                                                                  },
                                                                                                                                                                                                                                   new QuestionAnswer()
                                                                                                                                                                                                                                   {
                                                                                                                                                                                                                                       QuestionId = 48,
                                                                                                                                                                                                                                       QuestionAnswerId = 207,
                                                                                                                                                                                                                                       Answer = "Direct Debit",
                                                                                                                                                                                                                                   },
                                                                                                                                                                                                                                    new QuestionAnswer()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        QuestionId = 48,
                                                                                                                                                                                                                                        QuestionAnswerId = 208,
                                                                                                                                                                                                                                        Answer = "Key meter (prepayment)",
                                                                                                                                                                                                                                    },
                                                                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                                                                     {
                                                                                                                                                                                                                                         QuestionId = 48,
                                                                                                                                                                                                                                         QuestionAnswerId = 209,
                                                                                                                                                                                                                                         Answer = "Other",
                                                                                                                                                                                                                                     },
                                                                                                                                                                                                                                     //9
                                                                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                                                                     {
                                                                                                                                                                                                                                         QuestionId = 49,
                                                                                                                                                                                                                                         QuestionAnswerId = 210,
                                                                                                                                                                                                                                         Answer = "Aged under 5 years",
                                                                                                                                                                                                                                     },
                                                                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                                                                     {
                                                                                                                                                                                                                                         QuestionId = 49,
                                                                                                                                                                                                                                         QuestionAnswerId = 211,
                                                                                                                                                                                                                                         Answer = "Under 16 years",
                                                                                                                                                                                                                                     },
                                                                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                                                                     {
                                                                                                                                                                                                                                         QuestionId = 49,
                                                                                                                                                                                                                                         QuestionAnswerId = 222,
                                                                                                                                                                                                                                         Answer = "17 - 25 years old",
                                                                                                                                                                                                                                     },
                                                                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                                                                     {
                                                                                                                                                                                                                                         QuestionId = 49,
                                                                                                                                                                                                                                         QuestionAnswerId = 223,
                                                                                                                                                                                                                                         Answer = "26 - 60 years old",
                                                                                                                                                                                                                                     },
                                                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                                                      {
                                                                                                                                                                                                                                          QuestionId = 49,
                                                                                                                                                                                                                                          QuestionAnswerId = 224,
                                                                                                                                                                                                                                          Answer = "61- 70 years old",
                                                                                                                                                                                                                                      },
                                                                                                                                                                                                                                       new QuestionAnswer()
                                                                                                                                                                                                                                       {
                                                                                                                                                                                                                                           QuestionId = 49,
                                                                                                                                                                                                                                           QuestionAnswerId = 225,
                                                                                                                                                                                                                                           Answer = "70+ years old",
                                                                                                                                                                                                                                       },
                                                                                                                                                                                                                                         //10
                                                                                                                                                                                                                                         new QuestionAnswer()
                                                                                                                                                                                                                                         {
                                                                                                                                                                                                                                             QuestionId = 50,
                                                                                                                                                                                                                                             QuestionAnswerId = 226,
                                                                                                                                                                                                                                             Answer = "Pre 1900",
                                                                                                                                                                                                                                         },
                                                                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                                                                           {
                                                                                                                                                                                                                                               QuestionId = 50,
                                                                                                                                                                                                                                               QuestionAnswerId = 227,
                                                                                                                                                                                                                                               Answer = "1900 - 1919",
                                                                                                                                                                                                                                           },
                                                                                                                                                                                                                                             new QuestionAnswer()
                                                                                                                                                                                                                                             {
                                                                                                                                                                                                                                                 QuestionId = 50,
                                                                                                                                                                                                                                                 QuestionAnswerId = 228,
                                                                                                                                                                                                                                                 Answer = "1920 - 1945",
                                                                                                                                                                                                                                             },
                                                                                                                                                                                                                                               new QuestionAnswer()
                                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                                   QuestionId = 50,
                                                                                                                                                                                                                                                   QuestionAnswerId = 229,
                                                                                                                                                                                                                                                   Answer = "1946 - 1979",
                                                                                                                                                                                                                                               },
                                                                                                                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                                                                                                                 {
                                                                                                                                                                                                                                                     QuestionId = 50,
                                                                                                                                                                                                                                                     QuestionAnswerId = 230,
                                                                                                                                                                                                                                                     Answer = "1980 - 1995",
                                                                                                                                                                                                                                                 },
                                                                                                                                                                                                                                                   new QuestionAnswer()
                                                                                                                                                                                                                                                   {
                                                                                                                                                                                                                                                       QuestionId = 50,
                                                                                                                                                                                                                                                       QuestionAnswerId = 231,
                                                                                                                                                                                                                                                       Answer = "1996 or after",
                                                                                                                                                                                                                                                   },
                                                                                                                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                                                                                                                     {
                                                                                                                                                                                                                                                         QuestionId = 50,
                                                                                                                                                                                                                                                         QuestionAnswerId = 232,
                                                                                                                                                                                                                                                         Answer = "Don't know",
                                                                                                                                                                                                                                                     },
                                                                                                                                                                                                                                                      //Survey 6
                                                                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                                                                      {
                                                                                                                                                                                                                                                          QuestionId = 51,
                                                                                                                                                                                                                                                          QuestionAnswerId = 233,
                                                                                                                                                                                                                                                          Answer = "Yes",
                                                                                                                                                                                                                                                      },
                                                                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                                                                      {
                                                                                                                                                                                                                                                          QuestionId = 51,
                                                                                                                                                                                                                                                          QuestionAnswerId = 234,
                                                                                                                                                                                                                                                          Answer = "No",
                                                                                                                                                                                                                                                      },
                                                                                                                                                                                                                                                      //2
                                                                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                                                                      {
                                                                                                                                                                                                                                                          QuestionId = 52,
                                                                                                                                                                                                                                                          QuestionAnswerId = 235,
                                                                                                                                                                                                                                                          Answer = "Yes",
                                                                                                                                                                                                                                                      },
                                                                                                                                                                                                                                                      new QuestionAnswer()
                                                                                                                                                                                                                                                      {
                                                                                                                                                                                                                                                          QuestionId = 52,
                                                                                                                                                                                                                                                          QuestionAnswerId = 236,
                                                                                                                                                                                                                                                          Answer = "No",
                                                                                                                                                                                                                                                      },
                                                                                                                                                                                                                                                        new QuestionAnswer()
                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                            QuestionId = 52,
                                                                                                                                                                                                                                                            QuestionAnswerId = 237,
                                                                                                                                                                                                                                                            Answer = "SomeTimes",
                                                                                                                                                                                                                                                        },
                                                                                                                                                                                                                                                         //3
                                                                                                                                                                                                                                                         new QuestionAnswer()
                                                                                                                                                                                                                                                         {
                                                                                                                                                                                                                                                             QuestionId = 53,
                                                                                                                                                                                                                                                             QuestionAnswerId = 238,
                                                                                                                                                                                                                                                             Answer = "Yes",
                                                                                                                                                                                                                                                         },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 53,
                                                                                                                                                                                                                                                              QuestionAnswerId = 239,
                                                                                                                                                                                                                                                              Answer = "No",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                           //4
                                                                                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                                                                                           {
                                                                                                                                                                                                                                                               QuestionId = 54,
                                                                                                                                                                                                                                                               QuestionAnswerId = 240,
                                                                                                                                                                                                                                                               Answer = "Yes",
                                                                                                                                                                                                                                                           },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 54,
                                                                                                                                                                                                                                                              QuestionAnswerId = 241,
                                                                                                                                                                                                                                                              Answer = "No",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                                                                                           {
                                                                                                                                                                                                                                                               QuestionId = 54,
                                                                                                                                                                                                                                                               QuestionAnswerId = 242,
                                                                                                                                                                                                                                                               Answer = "Maybe",
                                                                                                                                                                                                                                                           },
                                                                                                                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                QuestionId = 54,
                                                                                                                                                                                                                                                                QuestionAnswerId = 243,
                                                                                                                                                                                                                                                                Answer = "No comment",
                                                                                                                                                                                                                                                            },
                                                                                                                                                                                                                                                            //5
                                                                                                                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                QuestionId = 55,
                                                                                                                                                                                                                                                                QuestionAnswerId = 244,
                                                                                                                                                                                                                                                                Answer = "Yes",
                                                                                                                                                                                                                                                            },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 55,
                                                                                                                                                                                                                                                              QuestionAnswerId = 245,
                                                                                                                                                                                                                                                              Answer = "No",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                            //6
                                                                                                                                                                                                                                                            new QuestionAnswer()
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                QuestionId = 56,
                                                                                                                                                                                                                                                                QuestionAnswerId = 246,
                                                                                                                                                                                                                                                                Answer = "Yes",
                                                                                                                                                                                                                                                            },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 56,
                                                                                                                                                                                                                                                              QuestionAnswerId = 247,
                                                                                                                                                                                                                                                              Answer = "No",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                          //7
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 57,
                                                                                                                                                                                                                                                              QuestionAnswerId = 248,
                                                                                                                                                                                                                                                              Answer = "Yes",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 57,
                                                                                                                                                                                                                                                              QuestionAnswerId = 249,
                                                                                                                                                                                                                                                              Answer = "No",
                                                                                                                                                                                                                                                          },

                                                                                                                                                                                                                                                           //8
                                                                                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                                                                                           {
                                                                                                                                                                                                                                                               QuestionId = 58,
                                                                                                                                                                                                                                                               QuestionAnswerId = 250,
                                                                                                                                                                                                                                                               Answer = "1-10 years",
                                                                                                                                                                                                                                                           },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 58,
                                                                                                                                                                                                                                                              QuestionAnswerId = 250,
                                                                                                                                                                                                                                                              Answer = "11-20 years",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 58,
                                                                                                                                                                                                                                                              QuestionAnswerId = 251,
                                                                                                                                                                                                                                                              Answer = "21-30 years",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 58,
                                                                                                                                                                                                                                                              QuestionAnswerId = 251,
                                                                                                                                                                                                                                                              Answer = "31+ years",
                                                                                                                                                                                                                                                          },
                                                                                                                                                                                                                                                           //9
                                                                                                                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                                                                                                                           {
                                                                                                                                                                                                                                                               QuestionId = 59,
                                                                                                                                                                                                                                                               QuestionAnswerId = 252,
                                                                                                                                                                                                                                                               Answer = "Yes",
                                                                                                                                                                                                                                                           },
                                                                                                                                                                                                                                                          new QuestionAnswer()
                                                                                                                                                                                                                                                          {
                                                                                                                                                                                                                                                              QuestionId = 59,
                                                                                                                                                                                                                                                              QuestionAnswerId = 253,
                                                                                                                                                                                                                                                              Answer = "No",
                                                                                                                                                                                                                                                          }
                                                                                             );
        }
    }
}