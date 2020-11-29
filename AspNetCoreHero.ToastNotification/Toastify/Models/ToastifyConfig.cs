namespace AspNetCoreHero.ToastNotification.Toastify.Models
{
    public class ToastifyConfig
    {
        public int DurationInSeconds { get; set; }
        public Position Position { get; set; } = Position.Right;
        public Gravity Gravity { get; set; } = Gravity.Bottom;
    }
}
