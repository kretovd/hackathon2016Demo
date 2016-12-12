﻿using Feedback.Core.Services;
using Feedback.UI.ViewModels.Base;
using Microsoft.Practices.Unity;

namespace Feedback.UI.ViewModels.Feedbacks.Implementation
{
    internal class FeedbacksFactory
    {
        private readonly IUnityContainer _container;

        public FeedbacksFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IAsyncCommand GetLoadFeedbacksCommand(FeedbacksViewModel viewModel)
        {
            var feedbackService = _container.Resolve<IFeedbackService>();
            var authenticationService = _container.Resolve<IAuthenticationService>();
            return new LoadFeedbacksCommand(viewModel, feedbackService, authenticationService);
        }

        public IAsyncCommand GetSaveFeedbackCommand(AddFeedbackViewModel viewModel)
        {
            var feedbackService = _container.Resolve<IFeedbackService>();
            var authenticationService = _container.Resolve<IAuthenticationService>();
            return new SaveFeedbackCommand(viewModel, feedbackService, authenticationService);
        }
    }
}