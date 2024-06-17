using System;
using System.Collections.Generic;
using System.Xml;
using SepaWriter.Utils;

namespace SepaWriter
{
    /// <summary>
    ///     Manage SEPA (Single Euro Payments Area) CreditTransfer for SEPA or international order.
    ///     Only one PaymentInformation is managed but it can manage multiple transactions.
    /// </summary>
    public class SepaPayment<T> where T : SepaTransferTransaction, ICloneable
	{
		protected readonly List<T> transactions = new List<T>();

		/// <summary>
		///     Requested Execution Date (default is object creation date)
		/// </summary>
		public DateTime RequestedExecutionDate { get; set; }


        /// <summary>
        ///     Return the XML string
        /// </summary>
        /// <returns></returns>
        //public string AsXmlString()
        //{
        //    return GenerateXml().OuterXml;
        //}

        ///// <summary>
        /////     Save in an XML file
        ///// </summary>
        //public void Save(string filename)
        //{
        //    GenerateXml().Save(filename);
        //}

        /// <summary>
        ///     Add an existing transfer transaction
        /// </summary>
        /// <param name="transfer"></param>
        /// <exception cref="ArgumentNullException">If transfert is null.</exception>
        public void AddTransfer(T transfer)
        {
            if (transfer == null)
                throw new ArgumentNullException("transfer");

            transfer = (T)transfer.Clone();
            transactions.Add(transfer);
        }

        public List<T> Transactions { 
            get { return transactions; } 
        }

    }
}