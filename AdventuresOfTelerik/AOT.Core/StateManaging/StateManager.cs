using AOT.Common.Exceptions;
using AOT.Common.Enums;
using AOT.Core.Abstractions;
using AOT.Common.Validation;

namespace AOT.Core.StateManaging
{
    internal class StateManager : IStateManager
    {
        private readonly IValidator validator;
        private readonly IScreenManager screenManager;
        private readonly IRender render;
        private readonly IInputReader inputReader;

        public StateManager(IValidator validator, IScreenManager screenManager,
            IRender render, IInputReader inputReader)
        {
            this.validator = validator;

            this.validator.ValidateObjectForNull(screenManager);
            this.validator.ValidateObjectForNull(render);
            this.validator.ValidateObjectForNull(inputReader);

            this.screenManager = screenManager;
            this.render = render;
            this.inputReader = inputReader;
        }

        public void StartState(GameState state)
        {
            switch (state)
            {
                case GameState.Menu:
                    this.render.RenderScreen(this.screenManager.GenerateMenuScreen());
                    var input = this.inputReader.ReadLine();
                    this.render.PrintMsg(input);
                    break;
                case GameState.NewGame:
                    break;
                case GameState.LoadGame:
                    break;
                case GameState.Settings:
                    break;
                case GameState.Credits:
                    break;
                case GameState.Exit:
                    break;
                default:
                    throw new InvalidGameStateException(state);
            }
        }
    }
}
