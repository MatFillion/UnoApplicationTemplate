﻿using System;
using System.Collections.Generic;
using System.Text;
using Chinook.SectionsNavigation;
using Chinook.StackNavigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApplicationTemplate
{
	/// <summary>
	/// This class is used for navigation configuration.
	/// - Configures the navigator.
	/// </summary>
	public static class NavigationConfiguration
	{
		public static IServiceCollection AddNavigation(this IServiceCollection services)
		{
			return services.AddSingleton<ISectionsNavigator>(s =>
				new FrameSectionsNavigator(
					App.Instance.NavigationMultiFrame,
					GetPageRegistrations()
				)
			);
		}

		private static IReadOnlyDictionary<Type, Type> GetPageRegistrations() => new Dictionary<Type, Type>()
		{
			{ typeof(HomePageViewModel), typeof(HomePage) },
			{ typeof(PostsPageViewModel), typeof(PostsPage) },
			{ typeof(EditPostPageViewModel), typeof(EditPostPage) },
			{ typeof(DiagnosticsPageViewModel), typeof(DiagnosticsPage) },
			{ typeof(WelcomePageViewModel), typeof(WelcomePage) },
			{ typeof(CreateAccountPageViewModel), typeof(CreateAccountPage) },
			{ typeof(ForgotPasswordPageViewModel), typeof(ForgotPasswordPage) },
			{ typeof(LoginPageViewModel), typeof(LoginPage) },
			{ typeof(OnboardingPageViewModel), typeof(OnboardingPage) },
			{ typeof(SettingsPageViewModel), typeof(SettingsPage) },
			{ typeof(LicensesPageViewModel), typeof(LicensesPage) },
			{ typeof(WebViewPageViewModel), typeof(WebViewPage) },
			{ typeof(EnvironmentPickerPageViewModel), typeof(EnvironmentPickerPage) },
			{ typeof(EditProfilePageViewModel), typeof(EditProfilePage) },
			{ typeof(ChuckNorrisSearchPageViewModel), typeof(ChuckNorrisSearchPage) },
			{ typeof(ChuckNorrisFavoritesPageViewModel), typeof(ChuckNorrisFavoritesPage) },
		};

		private static void DisableAnimations()
		{
			MultiFrame.Animations.ChangeSectionAnimation_HideFrame1ToRevealFrame2 = MultiFrame.Animations.CollapseFrame1AndShowFrame2;
			MultiFrame.Animations.ChangeSectionAnimation_ShowFrame2ToHideFrame1 = MultiFrame.Animations.CollapseFrame1AndShowFrame2;
			MultiFrame.Animations.OpenModalAnimation = MultiFrame.Animations.CollapseFrame1AndShowFrame2;
			MultiFrame.Animations.CloseModalAnimation = MultiFrame.Animations.CollapseFrame1AndShowFrame2;
		}
	}
}
