using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Extensions;

public static class FeedBackExtension
{
    public static FeedBack MapToFeedBackModel(FeedBackViewModel feedBackViewModel)
    {
        FeedBack feedBack = new FeedBack()
        {
            Id = feedBackViewModel.Id,
            UserName = feedBackViewModel.UserName,
            Comments = feedBackViewModel.Comments,
            Grade = feedBackViewModel.Grade,
            PhoneId = feedBackViewModel.PhoneId
        };
        return feedBack;
    }
    
    public static List<FeedBackViewModel> MapToFeedBackViewModels(this IEnumerable<FeedBack> self)
    {
        return self.Select(p => new FeedBackViewModel
        {
            Id = p.Id,
            Comments = p.Comments,
            Grade = p.Grade,
            PhoneId = p.PhoneId,
            UserName = p.UserName
        }).ToList();
    }}