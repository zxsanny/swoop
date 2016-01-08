using System;
using System.Net;
using System.Threading;
using log4net;
using Swoop.Common.Models;

namespace Swoop.Common
{
    internal interface ITrackerApi
    {
        TrackerInfo TrackerInfo { get; }
        /// <summary>
        /// Provide seed information by id. GetPageContent(id) will be handy - it returns html page for seed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Seed GetSeed(int id);
    }

    public abstract class BaseTrackerApi : ITrackerApi
    {
        private readonly ILog logger;
        
        public abstract TrackerInfo TrackerInfo { get; }
        public abstract Seed GetSeed(int id);

        protected virtual WebClient Client
        {
            get { return new WebClient(); }
        }

        protected BaseTrackerApi(ILog logger)
        {
            this.logger = logger;
        }

        protected string GetPageContent(int id)
        {
            var url = TrackerInfo.SeedTemplate + id;
            var attempts = 0;
            var longAttempts = 0;

            var cantConnectStr = string.Concat("Can't connect to ", url, " Please check your internet connection and your access to this resource!");
            do
            {
                do
                {
                    try
                    {
                        return Client.DownloadString(url);
                    }
                    catch (Exception e)
                    {
                        logger.Error(cantConnectStr + " One more times retry...", e);
                        attempts++;
                        Thread.Sleep(2000);
                    }
                } while (attempts < 5);
                logger.Error(cantConnectStr + "Waiting for 10 minutes...");
                Thread.Sleep(30*60*1000);
                attempts = 0;
                longAttempts++;
            } while (longAttempts < 60);
            throw new Exception(cantConnectStr + " Stop grabber after 10 hours of waiting for connection!");
        }
    }
}