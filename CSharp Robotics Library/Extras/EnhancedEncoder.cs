﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPILib;
using CSharpRoboticsLib.NILabview;

namespace CSharpRoboticsLib.Extras
{
    /// <summary>
    /// An encoder with additional functionality and corrected rate acquisition
    /// </summary>
    public class EnhancedEncoder : Encoder
    {
        private Derivative m_velocityFilter;

        /// <summary>
        /// Resets the encoder when this DigitalInput is pressed
        /// </summary>
        public DigitalInput ResetOn { get; set; }

        /// <summary>
        /// CSharpRoboticslib.Extras.EnhancedEncoder
        /// </summary>
        /// <param name="aChannel"></param>
        /// <param name="bChannel"></param>
        public EnhancedEncoder(int aChannel, int bChannel) : base(aChannel, bChannel)
        {
            m_velocityFilter = new Derivative();
        }

        /// <summary>
        /// Sets <see cref="DistancePerPulse"/> to the proper value given by diameter of a wheel and counts per revolution
        /// </summary>
        /// <param name="WheelDiameter">Diameter of the wheel. Units used here will determine units of <see cref="GetRate"/></param>
        /// <param name="CountPerRevolution">Counts per revolution of the encoder. Usually 360 or 250.</param>
        public void SetDistancePerPulse(double WheelDiameter, int CountPerRevolution)
        {
            DistancePerPulse = (Math.PI * WheelDiameter) / CountPerRevolution;
        }

        /// <summary>
        /// Gets the velocity reported by the encoder.
        /// </summary>
        /// <returns>Derivative of the distance</returns>
        public new double GetRate()
        {
            return m_velocityFilter.Get(GetDistance());
        }

        /// <summary>
        /// Updates the derivative and 
        /// </summary>
        public void Update()
        {
            if (ResetOn?.Get() ?? false)
                Reset();
        }

        /// <summary>
        /// Resets the encoder and derivative
        /// </summary>
        public new void Reset()
        {
            base.Reset();
            m_velocityFilter.ReInitialize();
        }
    }
}
