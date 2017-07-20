using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ph_model;

namespace ph_logic
{
    public static class Utility
    {
        public static bool IsUserValid(string name, string password, bool requireAdmin = false)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var isValid = false;

            using (var db = PhContext.CreateContext())
            {
                var user = db.UserSet.FirstOrDefault(u => (u.Email == name || u.Username == name) && requireAdmin ? u.RoleType == RoleType.Admin : true );
                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                        isValid = true;
                }
            }

            return isValid;
        }

        #region randoms

        static Random s_random = new Random();

        // Generates a random number
        public static int RandomNumber(int min, int max)
        {
            return s_random.Next(min, max + 1);
        }

        // Generates a random string with the given length
        public static string RandomString(int size, bool lowerCase = false)
        {
            string s = string.Empty;
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * s_random.NextDouble() + 65)));
                s = s + ch;
            }
            return lowerCase ? s.ToLower() : s;
        }

        #endregion

        #region positions

        //POSITIONS
        //Calculate Position on Canvas 
        public static Position GetOrbitalObjectPosition(double radius, double angle, Position center, int scale)
        {
            Position rad = new Position();

            //Convert degrees to radians
            var angleRad = angle * Math.PI / 180;

            //Calculate Y Radius
            rad.X = radius * scale;
            rad.Y = 3 * radius * scale / 4;

            var position = new Position
            {
                X = center.X + (Math.Cos(angleRad)*rad.X),
                Y = center.Y + (Math.Sin(angleRad)*rad.Y)
            };

            return position;
        }
        public static Position GetFleetPosition(double radius, double angle, Position center)
        {
            //Convert degrees to radians
            var angleRad = angle * Math.PI / 180;

            Position position = new Position();
            position.X = center.X + (Math.Cos(angleRad) * radius);
            position.Y = center.Y + (Math.Sin(angleRad) * radius);

            return position;
        }
        public static Position GetStationLotsPosition(double radius, Position posdetail)
        {
            var position = new Position
            {
                X = posdetail.X + radius,
                Y = posdetail.Y
            };

            return position;
        }
        public static Position GetMoonPosition(double radius, double angle, double centerX, double centerY, double scale)
        {
            //Convert degrees to radians
            double angleRad;
            angleRad = angle * Math.PI / 180;

            var position = new Position
            {
                X = centerX + (Math.Cos(angleRad)*radius*scale),
                Y = centerY + (Math.Sin(angleRad)*radius*scale)
            };

            return position;
        }
        // Generate Orbital Radius based on Distance to Sun
        public static double GetOrbitalRadius(int distance)
        {
            double radius = 0;

            switch (distance)
            {
                case 0:
                    radius = RandomNumber(200, 240);
                    break;
                case 1:
                    radius = RandomNumber(265, 305);
                    break;
                case 2:
                    radius = RandomNumber(330, 370);
                    break;
                case 3:
                    radius = RandomNumber(395, 435);
                    break;
                case 4:
                    radius = RandomNumber(460, 500);
                    break;
                case 5:
                    radius = RandomNumber(525, 565);
                    break;
                case 6:
                    radius = RandomNumber(590, 630);
                    break;

            }

            return radius;
        }

        //Calculate distance between tow points
        public static double CalculateDistance(double originX, double originY, double destinationX, double destinationY)
        {
            double distanceX = originX - destinationX;
            double distanceY = originY - destinationY;

            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }

        #endregion



    }
}
