using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basic3Controllers.Controllers
{
    public class ModelBinding : Controller
    {
        //public IActionResult Priority()
        //{
        //    return JsonOn
        //}


        [Route("model/{version}")]
        public IActionResult FromRoute(string version)
        {
            return new ContentResult() { Content = $" Value from route {version}", ContentType = "text/plain" };
        }


      


        [Route("modelb/{rval}")]
        public IActionResult GetParameter([FromRoute] string rval, [FromQuery] string qVal, [FromBody] TestClass bval, [FromHeader] string hvalue)
        {
            return new ContentResult() { Content = $" Value from route ={rval}, query = {qVal} , body = {bval.name}, header ={hvalue},", ContentType = "text/plain" };
        }


        [Route("modelbindatclass/{rval}")]
        public IActionResult GetParameterfromClass(ModelbindingClass values)
        {
            return new ContentResult() { Content = $" Value from route ={values.rval}, query = {values.qVal} , body = {values.bval.name}, header ={values.hvalue},", ContentType = "text/plain" };
        }


        [Route("myForm/")]
        public IActionResult GetParameterfromform(MyForm values)
        {
            return new ContentResult() { Content = $" Value from form )form-data, xwww-form-urlencoded(small valueonly) id={values.id}, name = {values.name}, gender ={values.gender} ", ContentType = "text/plain" };
        }

        [Route("myFormBind/")]
        public IActionResult GetParameterfromBind([Bind (nameof (MyForm.id),nameof(MyForm.name))] MyForm values)
        {
            return new ContentResult() { Content = $" Bind  and neverbind id={values.id}, name = {values.name}, gender ={values.gender} ", ContentType = "text/plain" };
        }


        [Route("myFormValidate/")]
        public IActionResult validate(Contact mycontact)
        {

            if(!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();
                foreach(var value in ModelState.Values)
                {
                    foreach(var error in value.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }

                   
                }
                string errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }

            return new ContentResult() { Content = $" Your content is valid ", ContentType = "text/plain" };
        }


        [Route("myFormValidate2/")]
        public IActionResult validate2(NewContact mycontact)
        {

            if (!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }


                }
                string errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }

            return new ContentResult() { Content = $" Your content is valid ", ContentType = "text/plain" };
        }


        [Route("imputformatterofXML/")]
        public IActionResult inputformatterXML([FromBody]NewContact mycontact)
        {


            return new ContentResult() { Content = $" Add XmlSerilized as inputformatter in addcontroller and frombody .Your content is valid Dob={ mycontact.DateOfBirth} ", ContentType = "text/plain" };
        }

        [Route("mylist/")]
        public IActionResult getList(Mylist List)
        {
            return new ContentResult() { Content = $" List item 0 is {List.Tags[0]} ", ContentType = "text/plain" };
        }


    }

    public class Contact
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        //[ValidateNever]
        public string? Phone { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }


        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double? Price { get; set; }


        [ValidateNever]
        public string? MyValue { get; set; }

        [MinimumYearValidator(2005, ErrorMessage="Join year must be less then 2005")]
        public DateTime JoinDate { get; set; }



        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To date'")]
        public DateTime? ToDate { get; set; }


       


        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }


    public class Mylist
    {
        public List<string> Tags { get; set; } = new List<string>();
    }
    public class NewContact : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied", new[] { nameof(Age) });
            }
        }


       
        public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }
    }

    public class MyForm
    {
        public int id { get; set; }
        public string name { get; set; }
        [BindNever]
        public string gender { get; set; }
    }


    public class TestClass
    {
        public string name { get; set; }
    }

    public class ModelbindingClass
    {
        [FromRoute] 
        public string rval { get; set; }
        [FromQuery] 
        public string qVal { get;set; }
        [FromBody] 
        public TestClass bval { get; set; }
        [FromHeader] 
        public string hvalue { get; set; }
    }

}
