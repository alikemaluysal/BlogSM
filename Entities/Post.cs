using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Post : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }

    public User User { get; set; }
    public Category Category { get; set; }
    public List<Comment> Comments { get; set; }

}
