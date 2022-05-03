namespace ProviderQuality.Console
{
    public class BlueStar : Award
    {
        public BlueStar(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {

        }

        /// <summary>
        /// Overrides the parent method to apply BlueStar specific logic for updating quality before expiration is considered
        /// </summary>
        /// <remarks>
        /// BlueStar decrements quality twice as fast as other awards
        /// </remarks>
        protected override void UpdateQualityPreExpiration()
        {
            base.UpdateQualityPreExpiration();
            base.UpdateQualityPreExpiration();
        }

        /// <summary>
        /// Overrides the parent method to apply BlueStar specific logic for updating quality after expiration is considered
        /// </summary>
        /// /// <remarks>
        /// BlueStar decrements quality twice as fast as other awards
        /// </remarks>
        protected override void UpdateQualityPostExpiration()
        {
            base.UpdateQualityPostExpiration();
            base.UpdateQualityPostExpiration();
        }
    }
}
