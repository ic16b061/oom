namespace Task4
{
    public interface Product
    {
        /// <summary>
        /// get product description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// get EAN of product
        /// </summary>
        string EAN { get; }

        /// <summary>
        /// get product price
        /// </summary>
        /// <returns></returns>
        decimal Price { get; }

        /// <summary>
        /// update price of product
        /// </summary>
        void UpdatePrice(decimal price_new);
    }
}
