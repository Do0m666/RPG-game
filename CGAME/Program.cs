using System;
using System.Windows.Forms;

namespace CGAME
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            EditorForm f = new EditorForm();

            f.Show();

            double t = 0;
            double dt = 0.01666667; // 60 phisics updates in second

            double currentTime = Time.GetCurrentTime();
            double accumulator = 0;

            double newTime;
            double frameTime;

            double prevTime;

            bool isRun = true;

            f.FormClosed += delegate { isRun = false; };

            while (isRun)
            {
                prevTime = currentTime;

                newTime = Time.GetCurrentTime();

                frameTime = newTime - currentTime;

                if (frameTime > 0.25)
                {
                    frameTime = 0.25;
                }

                Time.UpdateDelta(frameTime);

                currentTime = newTime;

                accumulator += frameTime;

                while (accumulator >= dt)
                {

                    accumulator -= dt;
                    t += dt;
                }

                f.CGUpdate();
                f.Refresh();

                Application.DoEvents();
            }

        }
    }

    public static class Time
    {
        public static double awake_time = 0.0f;

        public static double deltaTime { get; private set; }

        public static void UpdateDelta(double _frameTime)
        {
            deltaTime = _frameTime;
        }

        public const double fixedDeltaTime = 0.01666667;

        static Time()
        {
            awake_time = GetCurrentTime();
        }

        public static double GetCurrentTime()
        {
            return ((double)DateTime.Now.Ticks / TimeSpan.TicksPerSecond) - awake_time;
        }
    }
}
