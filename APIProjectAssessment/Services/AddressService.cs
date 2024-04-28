using APIProjectAssessment.EFDBContext;
using APIProjectAssessment.Helper;
using APIProjectAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProjectAssessment.Services
{
    public class AddressService
    {
        private readonly AppDBContext _dbContext;
        public AddressService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task<int> AddAddress(AddressLocationModel addressModel,string parentNode)
        {
            var res = 0;
            AddressLocationModel parent = null;
            AddressLocationModel childNode = null;
            try
            {
                if (addressModel != null)
                {
                    if (parentNode != "" && parentNode != null) { 
                        parent = await _dbContext.addresses.FirstOrDefaultAsync(x => x.Name == parentNode);


                        //if (parent == null)
                        //{
                        //    AddressLocationModel parNode = new AddressLocationModel();
                        //    parNode.Name = parentNode;
                        //    await _dbContext.addresses.AddAsync(parNode);
                        //    res = await _dbContext.SaveChangesAsync();

                        //    parent = await _dbContext.addresses.FirstOrDefaultAsync(x => x.Name == parentNode);
                        //}

                        //if (addressModel != null)
                        //{
                        //    childNode = await _dbContext.addresses.FirstOrDefaultAsync
                        //        (x => x.Name == addressModel.Name && x.ParentID == parent.AddressID);
                        //}
                    }
                   
                    if(parent != null)
                    {
                        addressModel.ParentID = parent.AddressID;
                        childNode = await _dbContext.addresses.FirstOrDefaultAsync
                            (x => x.Name == addressModel.Name && x.ParentID == parent.AddressID);

                    }
                    if(childNode == null)
                    {
                        if (parentNode == "")
                        {
                            childNode = await _dbContext.addresses.FirstOrDefaultAsync
                            (x => x.Name == addressModel.Name);
                            if (childNode == null)
                            {
                                addressModel.AddressID = 0;
                                await _dbContext.addresses.AddAsync(addressModel);
                                res = await _dbContext.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            addressModel.AddressID = 0;
                            await _dbContext.addresses.AddAsync(addressModel);
                            res = await _dbContext.SaveChangesAsync();
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                string msg = "Error :" + DateTime.Now + ">>>>" + ex.Message;
                General.WriteLogInTextFile(msg);
            }
            return res;
        }
    }
}
