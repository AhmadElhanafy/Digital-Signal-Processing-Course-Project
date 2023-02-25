﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class TimeDelay:Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public float InputSamplingPeriod { get; set; }
        public float OutputTimeDelay { get; set; }

        public override void Run()
        {
            DirectCorrelation Dc = new DirectCorrelation
            {
                InputSignal1 = InputSignal1,
                InputSignal2 = InputSignal2
            };

            Dc.Run();

            float Max = 0;

            for (int i = 0; i < Dc.OutputNonNormalizedCorrelation.Count; i++)
            {
                if (Max < Math.Abs(Dc.OutputNonNormalizedCorrelation[i]))
                {
                    Max = i;
                }
            }

            OutputTimeDelay = Max * InputSamplingPeriod;
        }
    }
}