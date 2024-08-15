using BloggApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BloggApp.Viewcomponent
{
    public class Header : ViewComponent
    {
        private ITagRepository _tagRepository;
        public Header(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _tagRepository.Tags.ToListAsync());
        }
    }
}