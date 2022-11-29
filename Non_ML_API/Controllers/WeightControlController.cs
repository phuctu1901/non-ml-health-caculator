using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection;

namespace Non_ML_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightControlController : ControllerBase
    {
        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult BasalMetabolicRate(double weight, double height, double age, char gender)
        {
            double BMR = 0;
            // M == men, height in cm, weight in kg
            if (gender.CompareTo('M') == 0)
            {
                BMR = 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
            }
            else
            {
                BMR = 655 + (9.563 * weight) + (1.850 * height) - (4.676 * age);
            }
            return Ok(new { index = new { BMR = Math.Round(BMR, 2) }});
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult BodyMassIndex(double weight, double height)
        {
            // height in meter, weight in kg
            double BMI;
            BMI = weight / (height * height);
            return Ok(new { index = new { BMI = Math.Round(BMI, 2) } });
        }


        // men as 50 + (0.91 × [height in centimeters − 152.4]) and in women as 45.5 + (0.91 × [height in centimeters − 152.4]).


        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult IdealWeightCalculator( double height, char gender)
        {
            double weight = 0;
            if (gender.CompareTo('M') == 0)
            {
                weight = 50 + (0.91 * (height - 152.4));
            }
            else {
                weight = 45.5 + (0.91 * (height - 152.4));
            }
            return Ok(new { index = new { weight = Math.Round(weight, 2) } });
        }


        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult WeightMaintainingCaculator(double weight, double height, double age, char gender, double activity_factor)
        {

    //        If you are sedentary(little or no exercise) : Calorie - Calculation = BMR x 1.2
    //        If you are lightly active(light exercise / sports 1 - 3 days / week) : Calorie - Calculation = BMR x 1.375
    //        If you are moderatetely active(moderate exercise / sports 3 - 5 days / week) : Calorie - Calculation = BMR x 1.55
    //        If you are very active(hard exercise / sports 6 - 7 days a week) : Calorie - Calculation = BMR x 1.725
    //        If you are extra active(very hard exercise / sports & physical job or 2x training) : Calorie - Calculation = BMR x 1.9

            double BMR = 0;
            // M == men, 
            if (gender.CompareTo('M') == 0)
            {
                BMR = 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
            }
            else
            {
                BMR = 655 + (9.563 * weight) + (1.850 * height) - (4.676 * age);
            }
            return Ok(new { index = new { Calorie_Calculation = Math.Round(BMR*activity_factor, 2) } });
        }

        //https://www.gaiam.com/blogs/discover/how-to-calculate-your-ideal-body-fat-percentage

        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult BodyFatCaculator(double weight, double height, int age, char gender)
        {
            // height in meter, weight in kg
            double BMI;
            double bodyFatPercentage = 0;
            BMI = weight / (height * height);
            if (gender.CompareTo('M') == 0)
            {
                bodyFatPercentage = (1.20 * BMI) + (0.23 * age - 16.2);
            }
            else
            {
                bodyFatPercentage = (1.20 * BMI) + (0.23 * age - 5.4);
            }

            return Ok(new { index = new { bodyFatPercentage = Math.Round(bodyFatPercentage, 2) } });
        }
    }
}