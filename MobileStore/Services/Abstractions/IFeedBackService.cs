using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IFeedBackService
{
    void Add(FeedBack feedBack);
    List<FeedBackViewModel> GetAll();
}