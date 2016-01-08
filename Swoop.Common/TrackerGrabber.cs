using System;
using System.Threading;
using log4net;
using Swoop.Common.Models;
using Swoop.Common.Repositories;

namespace Swoop.Common
{
    public interface ITrackerGrabber
    {
        void ContinueGrab(int forwardAttempts = 1000, int max = 0);
        void StopGrab();
        TrackerInfo TrackerInfo { get; }
    }

    public class TrackerGrabber : ITrackerGrabber
    {
        private readonly ITrackerApi trackerApi;
        private readonly ISeedsRepository seedsRepository;
        private readonly ITrackerRepository trackerRepository;
        private readonly ILog logger;
        
        private bool stopped;

        public TrackerGrabber(BaseTrackerApi trackerApi, ISeedsRepository seedsRepository, ITrackerRepository trackerRepository, ILog logger)
        {
            this.trackerApi = trackerApi;
            this.seedsRepository = seedsRepository;
            this.trackerRepository = trackerRepository;
            this.logger = logger;
        }

        public void ContinueGrab(int forwardMaxAttempts = 800, int max = 0)
        {
            stopped = false;
            int currentCheckpoint = 1;
            var seedTemplate = trackerApi.TrackerInfo.SeedTemplate;
            var trackerName = trackerApi.TrackerInfo.TrackerName;
            try
            {
                Seed seed;
                int forwardAttempts = 0;
                currentCheckpoint = Math.Max(trackerRepository.GetTrackerInfo(trackerName).Checkpoint, trackerApi.TrackerInfo.Checkpoint);
                do
                {
                    seed = trackerApi.GetSeed(currentCheckpoint);
                    trackerRepository.SaveCheckPoint(trackerName, ++currentCheckpoint);
                    if (seed == null)
                    {
                        forwardAttempts++;
                        logger.InfoFormat("{0}{1} -> not exists!", seedTemplate, currentCheckpoint - 1);
                    }
                    else
                    {
                        forwardAttempts = 0;
                        seedsRepository.AddSeed(seed);
                        logger.InfoFormat("{0}{1} -> Stored successfully!", seedTemplate, currentCheckpoint - 1);
                    }
                    Thread.Sleep(250);
                    if (stopped)
                        break;
                } while ((seed != null && seed.Created < DateTime.Now.AddDays(-1) || forwardAttempts < forwardMaxAttempts) && (max == 0 || currentCheckpoint < max));
                logger.InfoFormat("Stop grabber! ({0})", currentCheckpoint);
            }
            catch (Exception e)
            {
                logger.Error("Stop grabber! Having some troubles! url: " + seedTemplate + currentCheckpoint, e);
            }
        }
        public void StopGrab()
        {
            stopped = true;
        }
        public TrackerInfo TrackerInfo
        {
            get { return trackerApi.TrackerInfo; }
        }
    }
}
