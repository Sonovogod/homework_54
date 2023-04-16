using Microsoft.EntityFrameworkCore;
using MobileStore.Extensions;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Services;

public class FeedBackService : IFeedBackService
{
    private readonly MobileContext _db;

    public FeedBackService(MobileContext db)
    {
        _db = db;
    }

    public void Add(FeedBack feedBack)
    {
        _db.FeedBacks.Add(feedBack);
        _db.SaveChanges();
    }
    
    public List<FeedBackViewModel> GetAll()
    {
        var feedBacks = _db.FeedBacks
            .Include(x => x.Phone)
            .ToList();
        
        return feedBacks.MapToFeedBackViewModels();
    }
}