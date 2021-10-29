namespace Shared.Model
{
    public class CurrenciesConvertDetails
    {
        /// <summary>
        /// Արժույթը՝ դեպի որը կատարվում է փոխարկումը
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Գումարի չափը, որը ստացվում է փոխարկման արդյունքում 
        /// </summary>
        public double Value { get; set; }
    }
}
