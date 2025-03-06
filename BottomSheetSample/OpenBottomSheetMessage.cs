
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BottomSheetSample;

public class OpenBottomSheetMessage : ValueChangedMessage<bool>
{
    public OpenBottomSheetMessage(bool value) : base(value)
    {
    }
}
