using System;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public class InteractabilityController : IDisposable
    {
        private readonly IInteractabilityView interactabilityView;
        private readonly IInteractabilityModel interactabilityModel;

        public InteractabilityController(IInteractabilityView interactabilityView, IInteractabilityModel interactabilityModel)
        {
            this.interactabilityView = interactabilityView;
            this.interactabilityModel = interactabilityModel;
            Init();
        }

        public void Dispose()
        {
            Deinit();
        }

        private void Init()
        {

        }

        private void Deinit()
        {

        }
    }
}