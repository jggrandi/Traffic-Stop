internal interface IInputProvider
{
    bool IsMainKeyPressed { get; set; }

    int OptionSelected { get; set; }
}
