

namespace NextgenUI.AlertsEvaluation
{
    internal interface IInputProvider
    {

        Utils.ButtonStatus KeyStatus { get; set; }

        Alert.Intensity OptionSelected { get; set; }
    }
}
