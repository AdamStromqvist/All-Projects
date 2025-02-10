using OOSU2_Laboration3;
using OOSU2_Laboration3.BusinessLayer;
using OOSU2_Laboration3.PresentationLayer.ViewModels;
using OOSU2_Laboration3.PresentationLayer.Views;
using System.Windows;
using System.Windows.Input;

//ViewModel for handling the login logic in the application
public class LoginViewModel : ObservableObject
{
    private string _username;
    private string _password;
    private string _errorMessage;
    private bool _isErrorVisible;
    private readonly ILoginService _loginService;
    public Action CloseAction { get; set; } 
    //Delegate for actions to perform after successful login (like closing the login window).

//Constructor initializing the login service and commands.
    public LoginViewModel(ILoginService loginService)
    {
        _loginService = loginService;
        LoginCommand = new RelayCommand(async () => await LoginAsync(), () => CanLogin());
    }
//Username bound to the username input in the UI.
    public string Username
    {
        get => _username;
        set
        {
            SetProperty(ref _username, value);
            OnPropertyChanged(nameof(CanLogin)); 
        }
    }
//Password bound to the password input in the UI.
    public string Password
    {
        get => _password;
        set
        {
            SetProperty(ref _password, value);
            OnPropertyChanged(nameof(CanLogin)); //Notify that the CanLogin property may have changed
        }
    }
//Message displayed in the UI when an error occurs during login.
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            SetProperty(ref _errorMessage, value);
            IsErrorVisible = !string.IsNullOrEmpty(value); // Update visibility when setting error message
        }
    }
//Controls the visibility of the error message in the UI.
    public bool IsErrorVisible
    {
        get => _isErrorVisible;
        set => SetProperty(ref _isErrorVisible, value);
    }
//Command that triggers the login process.
    public ICommand LoginCommand { get; }

//Checks if login can be attempted (cant be null username and password ).
    private bool CanLogin() => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

//Attempts to login using the provided credentials
    private async Task LoginAsync()
    {
        ErrorMessage = string.Empty; //Clear previous errors
        var isValid = await _loginService.ValidateLoginAsync(Username, Password);
        if (isValid)
        {
            MainMenuView mainMenuView = new MainMenuView();
            mainMenuView.Show();
            CloseAction?.Invoke(); //Close the login view if provided by the authorized
        }
        else
        {
            ErrorMessage = "Felaktigt användarnamn eller lösenord"; //Display an error message if login fails
        }
    }
}
