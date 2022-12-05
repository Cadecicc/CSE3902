using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace GG3902
{
    public class StateManager
    {
        private static StateManager instance = new StateManager();

        private Dictionary<string, IState> stateMap;

        public static StateManager Instance => instance;

        public StateManager()
        {
            stateMap = new Dictionary<string, IState>();
            stateMap.Add("Null", new NullState());
        }

        public void Reset()
        {
            stateMap = new Dictionary<string, IState>();
            stateMap.Add("Null", new NullState());
        }

        public void AddState(string name, IState state)
        {
            stateMap.Add(name, state);
        }

        public IState GetState(string name)
        {
            IState state;
            if (stateMap.ContainsKey(name))
            {
                state = stateMap[name];
            } 
            else
            {
                state = stateMap["Null"];
            }
           return stateMap[name];
        }
    }
}
