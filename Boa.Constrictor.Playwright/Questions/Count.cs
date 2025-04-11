using Boa.Constrictor.Screenplay;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Boa.Constrictor.Playwright
{
    /// <summary>
    /// Gets the count of the locator on the page
    /// </summary>
    public class Count : AbstractLocatorQuestion<int>
    {
        private Count(IPlaywrightLocator locator)
            : base(locator)
        {
        }

        public static Count Of(IPlaywrightLocator locator) => new Count(locator);

        /// <summary>
        /// Counts elements found by the locator.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public override async Task<int> RequestAsAsync(IActor actor, ILocator locator)
        {
            return await locator.CountAsync();
        }

        /// <summary>
        /// Provides string representation of the count question.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"count of elements found by {Locator.Description}";
    }
}