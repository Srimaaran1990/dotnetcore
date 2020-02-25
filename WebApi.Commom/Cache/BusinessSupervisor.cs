using DotnetCore.Business.Entities;
using DotnetCore.Business.Interfaces;
using DotnetCore.Web.Helpers;
using Neeyamo.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DotnetCore.Web.Models
{

    public class BusinessSupervisor
    {

        public static IBusiness _neeyamoSvr;
        public static IBusiness DotnetCoreSvr
        {
            get
            {
                if (_neeyamoSvr == null)
                    throw new ApplicationException("iGlobalPayController.iGlobalPaySvr: iGlobalPaySvr is null.");

                return _neeyamoSvr;
            }
            set { _neeyamoSvr = value; }
        }

        public string sessionAddressType = "AddressType";

        public string Set = "1";
        public string Get = "2";
        public int Zero = 0;

        public void ResetAll()
        {
            ResetAMSScenerio();
        }


        public async Task<List<MAS_AddressTypeDto>> GetMASAddressType(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                var fieldListTemp = new List<MAS_AddressTypeDto>();
                if (!RedisWrapper.Get(sessionAddressType, Zero, Zero, Zero, out fieldListTemp))
                {
                    fieldListTemp = await DotnetCoreSvr.GetMASAddressType(ct);
                    RedisWrapper.Add(fieldListTemp, sessionAddressType, Zero, Zero, Zero);
                }
                return fieldListTemp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MAS_AddressTypeDto> GetMASAddressTypeById(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                var result = await GetMASAddressType(ct);
                return result.FirstOrDefault(s => s.AddressTypeId == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertMASAddressType(MAS_AddressTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken))
        {
            var result = await DotnetCoreSvr.InsertMASAddressType(customObject, commit,ct);
            if (result != 0)
                ResetAMSScenerio();
            return result;
        }

        public async Task<bool> UpdateMASAddressType(MAS_AddressTypeDto customObject, bool commit, CancellationToken ct = default(CancellationToken))
        {
            var result = await DotnetCoreSvr.UpdateMASAddressType(customObject, commit,ct);
            if (result)
                ResetAMSScenerio();
            return result;
        }

        public async Task<bool> DeleteAMSScenerio(int id, bool commit, CancellationToken ct = default(CancellationToken))
        {
            var result = await GetMASAddressType(ct);
            var resultItem = result.FirstOrDefault(s => s.AddressTypeId == id);
            if (resultItem != null)
            {
                resultItem.IsDeleted = true;
                var isUpdated = await UpdateMASAddressType(resultItem, commit,ct);
                if (isUpdated)
                    ResetAMSScenerio();
                return isUpdated;
            }
            return false;
        }


        private void ResetAMSScenerio()
        {
            Task.Run(() =>
           {
               EntityChangeObserverMaster.DataSetObserver(sessionAddressType, Zero, Zero, Zero);
           });
        }
    }
}