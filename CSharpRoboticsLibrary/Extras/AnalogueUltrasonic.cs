﻿using WPILib;

namespace CSharpRoboticsLib.Extras
{
    /// <summary>
    /// An analogue Ultrasonic sensor class complete with built-in scaling
    /// </summary>
    class AnalogueUltrasonic : AnalogInput
    {
        private double scalingFactor;

        /// <summary>
        /// Creates a new Analogue Ultrasonic sensor on the specified port
        /// </summary>
        /// <param name="port">port to create the sensor with</param>
        /// <param name="scaleFactor">scaling factor to apply to the input voltage</param>
        public AnalogueUltrasonic(int port, double scaleFactor) : base(port)
        {
            scalingFactor = scaleFactor;
        }

        /// <summary>
        /// Gets the value of the ultrasonic sensor modified by the scaling factor
        /// </summary>
        /// <returns></returns>
        public double Get()
        {
            return GetAverageVoltage() / scalingFactor;
        }

        /// <summary>
        /// Gets the value of the ultrasonic sensor modified by the scaling factor
        /// </summary>
        /// <returns></returns>
        public new double PidGet() //Change to override when new version of WPILIB happens
        {
            return Get();
        }
    }
}
