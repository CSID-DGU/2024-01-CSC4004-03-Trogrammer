using System.Collections.Generic;
using MyApiProject.Models;

namespace MyApiProject.Controllers
{
    public static class Database
    {
        public enum Unit {
            gram,
            ml,
            piece
        }

        public static string ToString(Unit unit) {
            switch (unit) {
                case Unit.gram:  return "g";
                case Unit.ml:    return "ml";
                case Unit.piece: return "개";
                default:         return "";
            }
        }

        public struct Foodset {
            public Food food;
            public float amount;
            public Foodset(string name, float amount) {
                this.food = Database.Foods.Find(x => x.Name == name);
                this.amount = amount;
            }
        }

        public struct Menuset {
            public Recipe recipe;
            public float price;
            public string category;
            public Menuset(string name, float price, string category) {
                this.recipe = Database.Recipes.Find(x => x.Name == name);
                this.price = price;
                this.category = category;
            }
        }

        public struct Restaurant {
            public string name;
            public string url;
            public List<Menuset> menuset;
            public Restaurant(string name, List<Menuset> menuset) {
                this.name = name;
                this.url = "https://map.naver.com/p/search/" + name;
                this.menuset = menuset;
            }
        }

        public static List<Food> Foods { get; set; } = new List<Food>
        {
            new Food { Name = "김치", Amount = 100.0f, Unit = "gram", Price = 1000.0f },
            new Food { Name = "대파", Amount = 100.0f, Unit = "piece", Price = 1000.0f },
            new Food { Name = "두부", Amount = 100.0f, Unit = "piece", Price = 1000.0f },
            new Food { Name = "계란", Amount = 100.0f, Unit = "piece", Price = 1000.0f },
            new Food { Name = "소금", Amount = 100.0f, Unit = "gram", Price = 1000.0f },
            new Food { Name = "된장", Amount = 100.0f, Unit = "gram", Price = 2000.0f },
            new Food { Name = "감자", Amount = 200.0f, Unit = "gram", Price = 1500.0f },
            new Food { Name = "양파", Amount = 150.0f, Unit = "piece", Price = 800.0f },
            new Food { Name = "호박", Amount = 200.0f, Unit = "gram", Price = 1800.0f },
            new Food { Name = "고추", Amount = 50.0f, Unit = "gram", Price = 500.0f },
            new Food { Name = "파스타면", Amount = 200.0f, Unit = "gram", Price = 3000.0f },
            new Food { Name = "크림소스", Amount = 150.0f, Unit = "ml", Price = 2500.0f },
            new Food { Name = "버섯", Amount = 100.0f, Unit = "gram", Price = 1500.0f },
            new Food { Name = "치즈", Amount = 50.0f, Unit = "gram", Price = 2000.0f },
            new Food { Name = "짜장소스", Amount = 200.0f, Unit = "gram", Price = 2500.0f },
            new Food { Name = "돼지고기", Amount = 150.0f, Unit = "gram", Price = 3000.0f },
            new Food { Name = "짜장면면", Amount = 200.0f, Unit = "gram", Price = 2000.0f },
            new Food { Name = "피자도우", Amount = 300.0f, Unit = "gram", Price = 5000.0f },
            new Food { Name = "소고기", Amount = 200.0f, Unit = "gram", Price = 8000.0f },
            new Food { Name = "닭고기", Amount = 200.0f, Unit = "gram", Price = 5000.0f },
            new Food { Name = "생선", Amount = 200.0f, Unit = "gram", Price = 7000.0f },
            new Food { Name = "밥", Amount = 200.0f, Unit = "gram", Price = 1000.0f },
            new Food { Name = "간장", Amount = 50.0f, Unit = "ml", Price = 500.0f },
            new Food { Name = "오이", Amount = 100.0f, Unit = "gram", Price = 1500.0f },
            new Food { Name = "돼지 등심", Amount = 200.0f, Unit = "gram", Price = 5000.0f }
        };

        public static List<Recipe> Recipes { get; set; } = new List<Recipe>
        {
            new Recipe
            {
                Name = "김치찌개",
                Type = "Korean",
                Ingredients = new List<Food>
                {
                    new Food { Name = "김치", Amount = 100.0f, Unit = "gram", Price = 1000.0f },
                    new Food { Name = "대파", Amount = 1.0f, Unit = "piece", Price = 1000.0f },
                    new Food { Name = "두부", Amount = 1.0f, Unit = "piece", Price = 1000.0f }
                }
            },
            new Recipe
            {
                Name = "계란말이",
                Type = "Korean",
                Ingredients = new List<Food>
                {
                    new Food { Name = "계란", Amount = 4.0f, Unit = "piece", Price = 1000.0f },
                    new Food { Name = "대파", Amount = 1.0f, Unit = "piece", Price = 1000.0f },
                    new Food { Name = "소금", Amount = 1.0f, Unit = "gram", Price = 1000.0f }
                }
            },
            new Recipe
            {
                Name = "된장찌개",
                Type = "Korean",
                Ingredients = new List<Food>
                {
                    new Food { Name = "된장", Amount = 50.0f, Unit = "gram", Price = 2000.0f },
                    new Food { Name = "감자", Amount = 100.0f, Unit = "gram", Price = 1500.0f },
                    new Food { Name = "양파", Amount = 0.5f, Unit = "piece", Price = 800.0f },
                    new Food { Name = "호박", Amount = 100.0f, Unit = "gram", Price = 1800.0f },
                    new Food { Name = "고추", Amount = 10.0f, Unit = "gram", Price = 500.0f }
                }
            },
            new Recipe
            {
                Name = "크림파스타",
                Type = "Western",
                Ingredients = new List<Food>
                {
                    new Food { Name = "파스타면", Amount = 200.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "크림소스", Amount = 150.0f, Unit = "ml", Price = 2500.0f },
                    new Food { Name = "버섯", Amount = 50.0f, Unit = "gram", Price = 1500.0f },
                    new Food { Name = "치즈", Amount = 30.0f, Unit = "gram", Price = 2000.0f }
                }
            },
            new Recipe
            {
                Name = "짜장면",
                Type = "Chinese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "짜장소스", Amount = 200.0f, Unit = "gram", Price = 2500.0f },
                    new Food { Name = "돼지고기", Amount = 100.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "양파", Amount = 1.0f, Unit = "piece", Price = 800.0f },
                    new Food { Name = "짜장면", Amount = 200.0f, Unit = "gram", Price = 2000.0f }
                }
            },
            new Recipe
            {
                Name = "불고기",
                Type = "Korean",
                Ingredients = new List<Food>
                {
                    new Food { Name = "소고기", Amount = 200.0f, Unit = "gram", Price = 8000.0f },
                    new Food { Name = "양파", Amount = 1.0f, Unit = "piece", Price = 800.0f },
                    new Food { Name = "간장", Amount = 20.0f, Unit = "ml", Price = 500.0f }
                }
            },
            new Recipe
            {
                Name = "삼계탕",
                Type = "Korean",
                Ingredients = new List<Food>
                {
                    new Food { Name = "닭고기", Amount = 300.0f, Unit = "gram", Price = 5000.0f },
                    new Food { Name = "대파", Amount = 1.0f, Unit = "piece", Price = 1000.0f },
                    new Food { Name = "소금", Amount = 5.0f, Unit = "gram", Price = 1000.0f }
                }
            },
            new Recipe
            {
                Name = "비빔밥",
                Type = "Korean",
                Ingredients = new List<Food>
                {
                    new Food { Name = "밥", Amount = 200.0f, Unit = "gram", Price = 1000.0f },
                    new Food { Name = "김치", Amount = 50.0f, Unit = "gram", Price = 1000.0f },
                    new Food { Name = "계란", Amount = 1.0f, Unit = "piece", Price = 1000.0f }
                }
            },
            new Recipe
            {
                Name = "탕수육",
                Type = "Chinese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "돼지고기", Amount = 200.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "양파", Amount = 1.0f, Unit = "piece", Price = 800.0f },
                    new Food { Name = "간장", Amount = 30.0f, Unit = "ml", Price = 500.0f }
                }
            },
            new Recipe
            {
                Name = "짬뽕",
                Type = "Chinese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "돼지고기", Amount = 150.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "고추", Amount = 20.0f, Unit = "gram", Price = 500.0f },
                    new Food { Name = "양파", Amount = 1.0f, Unit = "piece", Price = 800.0f }
                }
            },
            new Recipe
            {
                Name = "마파두부",
                Type = "Chinese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "두부", Amount = 200.0f, Unit = "piece", Price = 1000.0f },
                    new Food { Name = "돼지고기", Amount = 100.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "양파", Amount = 1.0f, Unit = "piece", Price = 800.0f }
                }
            },
            new Recipe
            {
                Name = "초밥",
                Type = "Japanese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "밥", Amount = 200.0f, Unit = "gram", Price = 1000.0f },
                    new Food { Name = "생선", Amount = 100.0f, Unit = "gram", Price = 7000.0f },
                    new Food { Name = "간장", Amount = 10.0f, Unit = "ml", Price = 500.0f }
                }
            },
            new Recipe
            {
                Name = "라멘",
                Type = "Japanese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "돼지고기", Amount = 100.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "파스타면", Amount = 200.0f, Unit = "gram", Price = 3000.0f },
                    new Food { Name = "간장", Amount = 20.0f, Unit = "ml", Price = 500.0f }
                }
            },
            new Recipe
            {
                Name = "돈까스",
                Type = "Japanese",
                Ingredients = new List<Food>
                {
                    new Food { Name = "돼지 등심", Amount = 200.0f, Unit = "gram", Price = 5000.0f },
                    new Food { Name = "소금", Amount = 5.0f, Unit = "gram", Price = 1000.0f },
                    new Food { Name = "계란", Amount = 1.0f, Unit = "piece", Price = 1000.0f }
                }
            },
            new Recipe
            {
                Name = "스테이크",
                Type = "Western",
                Ingredients = new List<Food>
                {
                    new Food { Name = "소고기", Amount = 300.0f, Unit = "gram", Price = 8000.0f },
                    new Food { Name = "소금", Amount = 5.0f, Unit = "gram", Price = 1000.0f },
                    new Food { Name = "버섯", Amount = 50.0f, Unit = "gram", Price = 1500.0f }
                }
            },
            new Recipe
            {
                Name = "샐러드",
                Type = "Western",
                Ingredients = new List<Food>
                {
                    new Food { Name = "오이", Amount = 50.0f, Unit = "gram", Price = 1500.0f },
                    new Food { Name = "양파", Amount = 1.0f, Unit = "piece", Price = 800.0f },
                    new Food { Name = "소금", Amount = 5.0f, Unit = "gram", Price = 1000.0f }
                }
            },
            new Recipe
            {
                Name = "피자",
                Type = "Western",
                Ingredients = new List<Food>
                {
                    new Food { Name = "치즈", Amount = 100.0f, Unit = "gram", Price = 2000.0f },
                    new Food { Name = "버섯", Amount = 50.0f, Unit = "gram", Price = 1500.0f },
                    new Food { Name = "피자도우", Amount = 300.0f, Unit = "gram", Price = 5000.0f }
                }
            }
        };

        public readonly static List<Restaurant> Restaurants = new List<Restaurant>
        {
            new Restaurant("김치만선생 동대필동점", new List<Menuset>
            {
                new Menuset("김치찌개", 7000.0f, "김치찌개"),
                new Menuset("계란말이", 6000.0f, "계란말이")
            }),
            new Restaurant("황토골", new List<Menuset>
            {
                new Menuset("김치찌개", 8000.0f, "김치찌개"),
                new Menuset("된장찌개", 8000.0f, "된장찌개")
            }),
            new Restaurant("필동함박 충무로 본점", new List<Menuset>
            {
                new Menuset("까르보파스타", 11500.0f, "크림파스타"),
                new Menuset("투움바파스타", 11500.0f, "크림파스타")
            }),
            new Restaurant("홍짜장 동국대점", new List<Menuset>
            {
                new Menuset("짜장면", 5500.0f, "짜장면"),
                new Menuset("짬뽕", 6500.0f, "짬뽕")
            }),
            new Restaurant("평강삼계탕 장충점", new List<Menuset>
            {
                new Menuset("삼계탕", 17000.0f, "삼계탕")
            }),
            new Restaurant("일미정", new List<Menuset>
            {
                new Menuset("불고기", 8000.0f, "불고기"),
                new Menuset("된장찌개", 9000.0f, "된장찌개")
            }),
            new Restaurant("필동반점", new List<Menuset>
            {
                new Menuset("짬뽕", 7000.0f, "짬뽕"),
                new Menuset("짜장면", 6000.0f, "짜장면")
            }),
            new Restaurant("스시노칸도 충무로역점", new List<Menuset>
            {
                new Menuset("초밥", 22000.0f, "초밥")
            }),
            new Restaurant("스담", new List<Menuset>
            {
                new Menuset("초밥", 18000.0f, "초밥")
            }),
            new Restaurant("낙원의소바", new List<Menuset>
            {
                new Menuset("돈까스", 15000.0f, "돈까스"),
                new Menuset("로스카츠", 13000.0f, "돈까스")
            }),
            new Restaurant("서울카츠 충무로본점", new List<Menuset>
            {
                new Menuset("등심 카츠", 14000.0f, "돈까스"),
                new Menuset("안심 카츠", 15000.0f, "돈까스")
            }),
            new Restaurant("모리짱", new List<Menuset>
            {
                new Menuset("돈코츠라멘", 8000.0f, "라멘"),
                new Menuset("소유라멘", 7000.0f, "라멘")
            }),
            new Restaurant("도치피자 장충점", new List<Menuset>
            {
                new Menuset("디아볼라 피자", 24000.0f, "피자"),
                new Menuset("고르곤졸라 피자", 22000.0f, "피자")
            }),
            new Restaurant("미스터피자 충무로점", new List<Menuset>
            {
                new Menuset("포테이토골드 피자", 31500.0f, "피자"),
                new Menuset("페퍼로니 피자", 20500.0f, "피자"),
                new Menuset("콤비네이션 피자", 21500.0f, "피자")
            })
        };
    }
}
