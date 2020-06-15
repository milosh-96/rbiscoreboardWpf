using RBIScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Library
{
    public class Animations
    {

        private static async void AnimationHomerun(Inning inning,int duration)
        {
            // First Base On
            inning.FirstBase = true;
            await Task.Delay(duration / 2); // 
            // Second Base On
            inning.SecondBase = true;
            await Task.Delay((duration / 3));
            inning.FirstBase = false;

            await Task.Delay(duration / 2);
            inning.ThirdBase = true;
            await Task.Delay((duration / 5));
            inning.SecondBase = false;

            await Task.Delay(duration / 2);
            inning.HomeBase = true;
            await Task.Delay((duration / 5));
            inning.ThirdBase = false;

            await Task.Delay((duration / 3));
            inning.HomeBase = false;

        }
        public static async void AnimateHomerun(Inning inning,int duration = 200, int loops = 5)
        {

            AnimationHomerun(inning,duration);

            await Task.Delay((duration * 4));

            if (loops > 0)
            {
                for (int i = 0; i <= loops; i++)
                {
                    AnimationHomerun(inning,duration);
                    await Task.Delay((duration * 4));

                }
            }
        }
    }
}
