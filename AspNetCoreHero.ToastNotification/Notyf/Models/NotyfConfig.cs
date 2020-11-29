namespace AspNetCoreHero.ToastNotification
{
    public class NotyfConfig
    {
        public int DurationInSeconds { get; set; }
        public NotyfPosition Position { get; set; } = NotyfPosition.BottomRight;
        public bool IsDismissable { get; set; } = false;
        public bool HasRippleEffect { get; set; } = true;
    }
}
