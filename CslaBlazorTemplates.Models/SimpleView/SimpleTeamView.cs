//using Csla;
//using CslaBlazorTemplates.Contracts.SimpleView;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CslaBlazorTemplates.Models.SimpleView
//{
//    /// <summary>
//    /// Represents a read-only team object.
//    /// </summary>
//    [Serializable]
//    internal class SimpleTeamView : ReadOnlyBase<SimpleTeamView>
//    {
//        #region Properties

//        public static readonly PropertyInfo<long?> TeamKeyProperty = RegisterProperty<long?>(nameof(TeamKey));
//        public long? TeamKey
//        {
//            get => GetProperty(TeamKeyProperty);
//            private set => LoadProperty(TeamKeyProperty, value);
//        }

//        public static readonly PropertyInfo<string> TeamCodeProperty = RegisterProperty<string>(c => c.TeamCode);
//        public string TeamCode
//        {
//            get { return GetProperty(TeamCodeProperty); }
//            private set { LoadProperty(TeamCodeProperty, value); }
//        }

//        public static readonly PropertyInfo<string> TeamNameProperty = RegisterProperty<string>(c => c.TeamName);
//        public string TeamName
//        {
//            get { return GetProperty(TeamNameProperty); }
//            private set { LoadProperty(TeamNameProperty, value); }
//        }

//        #endregion

//        #region Business Rules

//        //protected override void AddBusinessRules()
//        //{
//        //    // Add authorization rules.
//        //    BusinessRules.AddRule(new IsInRole(
//        //        AuthorizationActions.ReadProperty, TeamNameProperty, "Manager"));
//        //}

//        //private static void AddObjectAuthorizationRules()
//        //{
//        //    // Add authorization rules.
//        //    BusinessRules.AddRule(
//        //        typeof(SimpleTeamView),
//        //        new IsInRole(AuthorizationActions.GetObject, "Manager")
//        //        );
//        //}

//        #endregion

//        #region Factory Methods

//        private SimpleTeamView()
//        { /* require use of factory methods */ }

//        /// <summary>
//        /// Gets the specified read-only team instance.
//        /// </summary>
//        /// <param name="criteria">The criteria of the read-only team.</param>
//        /// <returns>The requested read-only team instance.</returns>
//        public static async Task<SimpleTeamView> Get(
//            SimpleTeamViewCriteria criteria,
//            [Inject] DataPortal<SimpleTeamView> dataPortal
//            )
//        {
//            return await dataPortal.FetchAsync(criteria);
//        }

//        #endregion

//        #region Data Access

//        private void DataPortal_Fetch(
//            SimpleTeamViewCriteria criteria
//            )
//        {
//            // Load values from persistent storage.
//            using (IDalManager dm = DalFactory.GetManager())
//            {
//                ISimpleTeamViewDal dal = dm.GetProvider<ISimpleTeamViewDal>();
//                SimpleTeamViewDto dto = dal.Fetch(criteria);

//                TeamKey = dto.TeamKey;
//                TeamCode = dto.TeamCode;
//                TeamName = dto.TeamName;
//            }
//        }

//        #endregion
//    }
//}
