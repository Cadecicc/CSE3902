using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GG3902
{
    public static class StringConversion
    {
        public static object ConvertFromToString(string value, Type type)
        {
            if (type == typeof(string))
                return value;
            else if (type == typeof(bool))
                return Convert.ToBoolean(value);
            else if (type is IConvertible)
                return Convert.ChangeType(value, type);
            else if (type == typeof(Vector2))
            {
                string[] nums = value.Split(' ');
                if (nums.Length != 2)
                    return Vector2.Zero;
                else
                    return new Vector2((float)Convert.ChangeType(nums[0], typeof(float)), (float)Convert.ChangeType(nums[1], typeof(float)));
            }
            else if (type == typeof(Direction))
            {
                Direction direction;
                if (value.Equals("Direction.Up"))
                    direction = Direction.Up;
                else if (value.Equals("Direction.Down"))
                    direction = Direction.Down;
                else if (value.Equals("Direction.Left"))
                    direction = Direction.Left;
                else
                    direction = Direction.Right;
                return direction;
            }
            else if (type == typeof(int))
            {
                return Convert.ToInt32(value);
            }
            else if (type == typeof(Dictionary<string, int>))
            {
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                string[] kvps = value.Split(',');
                foreach (string kvp in kvps)
                {
                    string[] pair = kvp.Split('-');
                    dictionary.Add(pair[0], Convert.ToInt32(pair[1]));
                }
                return dictionary;

            }
            return null;
        }
    }
}
