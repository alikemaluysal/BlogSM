using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Comment : Entity
{
    public string Content { get; set; }
    public int? UserId { get; set; }
    public int? PostId { get; set; }

    public User? User { get; set; }
    public Post? Post { get; set; }
}
