﻿using System;
using TMPro;
using UI.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Windows
{
    [RequireComponent(typeof(UIFadeAnimation))]
    public class RegistrationWindow : UIElement, IRegistrationView
    {
        public event Action<UIRegistrationDetails> RegisterButtonClicked;

        public event Action BackButtonClicked;

        public string Email
        {
            set
            {
                if (emailInputField != null)
                {
                    emailInputField.text = value;
                }
            }
        }

        public string Password
        {
            set
            {
                if (passwordInputField != null)
                {
                    passwordInputField.text = value;
                }
            }
        }

        public string ConfirmPassword
        {
            set
            {
                if (confirmPasswordInputField != null)
                {
                    confirmPasswordInputField.text = value;
                }
            }
        }

        public string FirstName
        {
            set
            {
                if (firstNameInputField != null)
                {
                    firstNameInputField.text = value;
                }
            }
        }

        public string LastName
        {
            set
            {
                if (lastNameInputField != null)
                {
                    lastNameInputField.text = value;
                }
            }
        }

        [Header("Input Fields")]
        [SerializeField]
        private TMP_InputField emailInputField;

        [SerializeField]
        private TMP_InputField passwordInputField;

        [SerializeField]
        private TMP_InputField confirmPasswordInputField;

        [SerializeField]
        private TMP_InputField firstNameInputField;

        [SerializeField]
        private TMP_InputField lastNameInputField;

        [Header("Buttons")]
        [SerializeField]
        private Button backButton;

        [SerializeField]
        private Button registerButton;

        private void Start()
        {
            if (backButton != null)
            {
                backButton.onClick.AddListener(OnBackButtonClicked);
            }

            if (registerButton != null)
            {
                registerButton.onClick.AddListener(OnRegisterButtonClicked);
            }
        }

        private void OnDestroy()
        {
            if (backButton != null)
            {
                backButton.onClick.RemoveListener(OnBackButtonClicked);
            }

            if (registerButton != null)
            {
                registerButton.onClick.RemoveListener(OnRegisterButtonClicked);
            }
        }

        private void OnBackButtonClicked()
        {
            BackButtonClicked?.Invoke();
        }

        private void OnRegisterButtonClicked()
        {
            var email = emailInputField?.text;
            var password = passwordInputField?.text;
            var confirmPassword = confirmPasswordInputField?.text;
            var firstName = firstNameInputField?.text;
            var lastName = lastNameInputField?.text;

            RegisterButtonClicked?.Invoke(
                new UIRegistrationDetails(
                    email,
                    password,
                    confirmPassword,
                    firstName,
                    lastName));
        }
    }
}