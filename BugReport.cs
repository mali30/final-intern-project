using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pluralsight.CustomerService.Models
{
    /*
    public enum BugType
    {
        Security = 1,
        Crash = 2,
        Power = 3,
        Performance = 4,
        Usability = 5,
        SeriousBug = 6,
        Other = 7
    }

    public enum Reproducibility
    {
        Always = 1,
        Sometimes = 2,
        Rarely = 3,
        Unable = 4
    }
    */
    [Serializable]
    public class BugReport
    {

        public string Title;
        [Prompt("Whats your flight number")]
        public string Description;
        [Prompt("What is your first name")]
        public string FirstName;
        [Prompt("What is your last name")]
        public string LastName;
        [Prompt("What is the best day and time for a callback")]
        public DateTime? BestTimeofDayToCall;
        [Pattern("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$")]
        public string Phonenumber;
        //[Prompt("Please list the form  areas that best describe your issue.{||}")]
        //public List<BugType> Bug;
        //public Reproducibility Reproduce;


        // creating a static function that returns a type of IForm
        // which is a gneric type of bugReport. It sening a form interface 
        // of itslef back.


        public static IForm<BugReport> BuildForm()
        {
            return new FormBuilder<BugReport>().Message("Please fill out the form").Build();

        }
    }
}