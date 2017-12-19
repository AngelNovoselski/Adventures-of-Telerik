using AOT.Common.Enums;
using AOT.Common.Validation;
using AOT.Core.Abstractions;
using AOT.Core.ScreenManaging;
using AOT.Core.StateManaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOT.Core
{
    public sealed class Engine
    {
        private static volatile Engine instance;
        private static object lockObject = new Object();
        private readonly IValidator validator;

        private IStateManager stateManager;
        private IScreenManager screenManager;
        //private bool isRunning;

        private Engine()
        {
            this.validator = new Validator();
            //this.isRunning = true;
        }

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Engine();
                        }
                    }
                }

                return instance;
            }
        }

        public void Initialize(IRender render, IInputReader inputReader)
        {
            this.validator.ValidateObjectForNull(render);
            this.screenManager = new ScreenManager();
            this.stateManager = new StateManager(this.validator, this.screenManager, render, inputReader);
        }

        public void Start()
        {
            this.stateManager.StartState(GameState.Menu);
        }
    }
}
