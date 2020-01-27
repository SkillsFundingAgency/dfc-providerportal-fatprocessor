using System.Collections.Generic;
using System.Linq;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public class Organisation
    {
        private readonly IEnumerable<IApprenticeship> _apprenticeships;
        private readonly IEnumerable<ILocation> _locations;

        private readonly int _id;
        private readonly int _ukprn;
        private readonly string _name;
        private readonly string _tradingName;
        private readonly bool _national;
        private readonly string _marketingInfo;
        private readonly string _email;
        private readonly string _website;
        private readonly string _phone;
        private readonly double? _learnerSatisfaction;
        private readonly double? _employerSatisfaction;

        public Organisation(int id, int ukprn, string name, string tradingName, bool national, string marketingInfo, string email, string website, string phone, double? learnerSatisfaction, double? employerSatisfaction, IEnumerable<IApprenticeship> apprenticeships)
        {
            _id = id;
            _ukprn = ukprn;
            _name = name;
            _tradingName = tradingName;
            _national = national;
            _marketingInfo = marketingInfo;
            _email = email;
            _website = website;
            _phone = phone;
            _learnerSatisfaction = learnerSatisfaction;
            _employerSatisfaction = employerSatisfaction;
            _apprenticeships = apprenticeships;
        }

        public int Id => _id;

        public int Ukprn => _ukprn;

        public string Name => _name;

        public string TradingName => _tradingName ?? Name;

        public bool National => _national;

        public string MarketingInfo => _marketingInfo;

        public string Email => _email;

        public string Website => _website;

        public string Phone => _phone;

        public double? LearnerSatisfaction => _learnerSatisfaction;

        public double? EmployerSatisfaction => _employerSatisfaction;

        public IEnumerable<Standard> AvailableStandards =>
            _apprenticeships.OfType<Standard>()
                .Where(s => s.IsAvailable());

        public IEnumerable<Framework> AvailableFrameworks => 
            _apprenticeships.OfType<Framework>()
                .Where(f => f.IsAvailable());
    }
}