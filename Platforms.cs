using System;

namespace Xdit
{
    public class Platforms
    {
        public PlatformsEnum platform;

        // TODO : Must use constructor exept OsLook method. so the class define platform when class instantioted.

        // Check for which platform(Os, kernel) are used.  
        public PlatformsEnum OsLook()
        {
            if (OperatingSystem.IsWindows())
            {
                platform = PlatformsEnum.Windows;
                return PlatformsEnum.Windows;
            }
            else
            {
                platform = PlatformsEnum.linux;
                return PlatformsEnum.linux;
            }
        }// End of OsLook Method.

    }// end of Platfomrs Class 

    // no comment :)
    public enum PlatformsEnum
        {
            Windows = 1,
            linux,
        }// end of Platforms enumerator

}// end of Xdit Namespace