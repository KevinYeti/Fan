using Hangfire;
using Hangfire.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fan.Client
{
    public static class Job
    {
        private static SqlServerStorage _storage = null;
        private static BackgroundJobClient _client = null;

        public static void Init(string connection)
        {
            if (string.IsNullOrEmpty(connection))
                throw new ArgumentNullException();
            else if (_storage != null || _client != null)
                throw new Exception("Init has been already called.");
            else
            {
                _storage = new SqlServerStorage(connection);
                _client = new BackgroundJobClient(_storage);
                JobStorage.Current = _storage;
            }

        }

        public static string Enqueue(Expression<Action> method)
        {
            if (_storage == null || _client == null)
                throw new Exception("Init has not been called yet.");
            else
            {
                return _client.Enqueue(method);
            }
        }

        public static string Schedule(Expression<Action> method, TimeSpan delay)
        {
            if (_storage == null || _client == null)
                throw new Exception("Init has not been called yet.");
            else
            {
                return _client.Schedule(method, delay);
            }
        }

        public static void Recurring(Expression<Action> method, string cron)
        {
            RecurringJob.AddOrUpdate(method, cron);
        }

        public static string Continue(string jobId, Expression<Action> method)
        {
            if (_storage == null || _client == null)
                throw new Exception("Init has not been called yet.");
            else
            {
                return _client.ContinueWith(jobId, method);
            }
        }

        public static bool Requeue(string jobId, string fromState)
        {
            if (_storage == null || _client == null)
                throw new Exception("Init has not been called yet.");
            else
            {
                return _client.Requeue(jobId, fromState);
            }
        }

        public static bool Delete(string jobId, string fromState)
        {
            if (_storage == null || _client == null)
                throw new Exception("Init has not been called yet.");
            else
            {
                return _client.Delete(jobId, fromState);
            }
        }

        public static void RemoveRecurring(string recurringJobId)
        {
            RecurringJob.RemoveIfExists(recurringJobId);
        }

        public static void TriggerRecurring(string recurringJobId)
        {
            RecurringJob.Trigger(recurringJobId);
        }
    }
}
