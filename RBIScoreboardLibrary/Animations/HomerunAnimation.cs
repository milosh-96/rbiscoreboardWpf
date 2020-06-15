using System;
using System.Collections.Generic;
using System.Text;

namespace RBIScoreboardLibrary.Animations
{
    static class HomerunAnimation
    {
        private async void AnimationHomerun(int duration)
        {
            // First Base On
            this.Inning.FirstBase = true;
            await Task.Delay(duration / 2); // 
            // Second Base On
            this.Inning.SecondBase = true;
            await Task.Delay((duration / 3));
            this.Inning.FirstBase = false;

            await Task.Delay(duration / 2);
            this.Inning.ThirdBase = true;
            await Task.Delay((duration / 5));
            this.Inning.SecondBase = false;

            await Task.Delay(duration / 2);
            this.Inning.HomeBase = true;
            await Task.Delay((duration / 5));
            this.Inning.ThirdBase = false;

            await Task.Delay((duration / 3));
            this.Inning.HomeBase = false;

        }
        public  static void AnimateHomerun(Inning inning,int duration = 200, int loops = 5)
        {

            this.AnimationHomerun(duration);

            await Task.Delay((duration * 4));

            if (loops > 0)
            {
                for (int i = 0; i <= loops; i++)
                {
                    this.AnimationHomerun(duration);
                    await Task.Delay((duration * 4));

                }
            }
        }
    }
}
