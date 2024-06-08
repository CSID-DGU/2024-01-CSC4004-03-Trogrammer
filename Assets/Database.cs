using System.Collections.Generic;

public static class Database {

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

    public struct Food {
        public string name;
        public float amount;
        public Unit unit;
        public float price;
        public Food(string name, float amount, Unit unit, float price) {
            this.name = name;
            this.amount = amount;
            this.unit = unit;
            this.price = price;
        }
    }

    public readonly static List<Food> food = new List<Food>{
        new Food("김치", 100.0f, Unit.gram,  1000.0f),
        new Food("대파", 100.0f, Unit.piece, 1000.0f),
        new Food("두부", 100.0f, Unit.piece, 1000.0f),
        new Food("계란", 100.0f, Unit.piece, 1000.0f),
        new Food("소금", 100.0f, Unit.gram,  1000.0f),

        new Food("된장", 100.0f, Unit.gram,  2000.0f),
        new Food("감자", 200.0f, Unit.gram,  1500.0f),
        new Food("양파", 150.0f, Unit.piece, 800.0f),
        new Food("호박", 200.0f, Unit.gram,  1800.0f),
        new Food("고추", 50.0f, Unit.gram,   500.0f),

        new Food("파스타면", 200.0f, Unit.gram,  3000.0f),
        new Food("크림소스", 150.0f, Unit.ml,    2500.0f),
        new Food("버섯", 100.0f, Unit.gram,      1500.0f),
        new Food("치즈", 50.0f, Unit.gram,       2000.0f),

        new Food("짜장소스", 200.0f, Unit.gram,  2500.0f),
        new Food("돼지고기", 150.0f, Unit.gram,  3000.0f),
        new Food("짜장면면", 200.0f, Unit.gram,  2000.0f),

        new Food("피자도우", 300.0f, Unit.gram,  5000.0f), 

        new Food("소고기", 200.0f, Unit.gram,  8000.0f),
        new Food("닭고기", 200.0f, Unit.gram,  5000.0f),
        new Food("생선", 200.0f, Unit.gram,  7000.0f),
        new Food("밥", 200.0f, Unit.gram,  1000.0f),
        new Food("간장", 50.0f, Unit.ml,  500.0f),
        new Food("오이", 100.0f, Unit.gram,  1500.0f),
        new Food("돼지 등심", 200.0f, Unit.gram,  5000.0f), 
    };

    public enum RecipeType {
        Korean,
        Chinese,
        Japanese,
        Western
    }

    public struct Foodset {
        public Food food;
        public float amount;
        public Foodset(string name, float amount) {
            this.food = Database.food.Find(x => x.name == name);
            this.amount = amount;
        }
    }

    public struct Recipe {
        public string name;
        public RecipeType type;
        public List<Foodset> foodset;
        public Recipe(string name, RecipeType type, List<Foodset> foodset) {
            this.name = name;
            this.type = type;
            this.foodset = foodset;
        }
    }

    public readonly static List<Recipe> recipe = new List<Recipe>{
        new Recipe("김치찌개", RecipeType.Korean, new List<Foodset>{
            new Foodset("김치", 100.0f),
            new Foodset("대파",   1.0f),
            new Foodset("두부",   1.0f),
        }),
        new Recipe("계란말이", RecipeType.Korean, new List<Foodset>{
            new Foodset("계란",   4.0f),
            new Foodset("대파",   1.0f),
            new Foodset("소금",   1.0f),
        }),

        new Recipe("된장찌개", RecipeType.Korean, new List<Foodset>{
            new Foodset("된장", 50.0f),
            new Foodset("감자", 100.0f),
            new Foodset("양파", 0.5f),
            new Foodset("호박", 100.0f),
            new Foodset("고추", 10.0f),
        }),

        new Recipe("크림파스타", RecipeType.Western, new List<Foodset>{
            new Foodset("파스타면", 200.0f),
            new Foodset("크림소스", 150.0f),
            new Foodset("버섯", 50.0f),
            new Foodset("치즈", 30.0f),
        }),

        new Recipe("짜장면", RecipeType.Chinese, new List<Foodset>{
            new Foodset("짜장소스", 200.0f),
            new Foodset("돼지고기", 100.0f),
            new Foodset("양파", 1.0f),
            new Foodset("짜장면면", 200.0f),
        }),

        new Recipe("불고기", RecipeType.Korean, new List<Foodset>{
            new Foodset("소고기", 200.0f),
            new Foodset("양파", 1.0f),
            new Foodset("간장", 20.0f),
        }),
        new Recipe("삼계탕", RecipeType.Korean, new List<Foodset>{
            new Foodset("닭고기", 300.0f),
            new Foodset("대파", 1.0f),
            new Foodset("소금", 5.0f),
        }),
        new Recipe("비빔밥", RecipeType.Korean, new List<Foodset>{
            new Foodset("밥", 200.0f),
            new Foodset("김치", 50.0f),
            new Foodset("계란", 1.0f),
        }),

        new Recipe("탕수육", RecipeType.Chinese, new List<Foodset>{
            new Foodset("돼지고기", 200.0f),
            new Foodset("양파", 1.0f),
            new Foodset("간장", 30.0f),
        }),
        new Recipe("짬뽕", RecipeType.Chinese, new List<Foodset>{
            new Foodset("돼지고기", 150.0f),
            new Foodset("고추", 20.0f),
            new Foodset("양파", 1.0f),
        }),
        new Recipe("마파두부", RecipeType.Chinese, new List<Foodset>{
            new Foodset("두부", 200.0f),
            new Foodset("돼지고기", 100.0f),
            new Foodset("양파", 1.0f),
        }),

        new Recipe("초밥", RecipeType.Japanese, new List<Foodset>{
            new Foodset("밥", 200.0f),
            new Foodset("생선", 100.0f),
            new Foodset("간장", 10.0f),
        }),
        new Recipe("라멘", RecipeType.Japanese, new List<Foodset>{
            new Foodset("돼지고기", 100.0f),
            new Foodset("파스타면", 200.0f),
            new Foodset("간장", 20.0f),
        }),
        new Recipe("돈까스", RecipeType.Japanese, new List<Foodset>{ 
            new Foodset("돼지 등심", 200.0f),
            new Foodset("소금", 5.0f),
            new Foodset("계란", 1.0f),
        }),

        new Recipe("스테이크", RecipeType.Western, new List<Foodset>{
            new Foodset("소고기", 300.0f),
            new Foodset("소금", 5.0f),
            new Foodset("버섯", 50.0f),
        }),
        new Recipe("샐러드", RecipeType.Western, new List<Foodset>{
            new Foodset("오이", 50.0f),
            new Foodset("양파", 1.0f),
            new Foodset("소금", 5.0f),
        }),
        new Recipe("피자", RecipeType.Western, new List<Foodset>{
            new Foodset("치즈", 100.0f),
            new Foodset("버섯", 50.0f),
            new Foodset("피자도우", 300.0f),
        }),
    };

    public struct Menuset {
        public Recipe recipe;
        public float price;
        public string category;
        public Menuset(string name, float price, string category) {
            this.recipe = Database.recipe.Find(x => x.name == name);
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

    public readonly static List<Restaurant> restaurant = new List<Restaurant>{
        new Restaurant("김치만선생 동대필동점", new List<Menuset>{
            new Menuset("김치찌개", 7000.0f, "김치찌개"),
            new Menuset("계란말이", 6000.0f, "계란말이"),
        }),

        new Restaurant("황토골", new List<Menuset>{
            new Menuset("김치찌개", 8000.0f, "김치찌개"),
            new Menuset("된장찌개", 8000.0f, "된장찌개"),
        }),

        new Restaurant("필동함박 충무로 본점", new List<Menuset>{
            new Menuset("까르보파스타", 11500.0f, "크림파스타"),
            new Menuset("투움바파스타", 11500.0f, "크림파스타"),
        }),
        new Restaurant("홍짜장 동국대점", new List<Menuset>{
            new Menuset("짜장면", 5500.0f, "짜장면"),
            new Menuset("짬뽕", 6500.0f, "짬뽕"),
        }),

        new Restaurant("평강삼계탕 장충점", new List<Menuset>{
            new Menuset("삼계탕", 17000.0f, "삼계탕"),
        }),
        new Restaurant("일미정", new List<Menuset>{
            new Menuset("불고기", 8000.0f, "불고기"),
            new Menuset("된장찌개", 9000.0f, "된장찌개"),
        }),
        new Restaurant("필동반점", new List<Menuset>{
            new Menuset("짬뽕", 7000.0f, "짬뽕"),
            new Menuset("짜장면", 6000.0f, "짜장면"),
        }),
        new Restaurant("스시노칸도 충무로역점", new List<Menuset>{
            new Menuset("초밥", 22000.0f, "초밥"),
        }),
        new Restaurant("스담", new List<Menuset>{
            new Menuset("초밥", 18000.0f, "초밥"),
        }),
        new Restaurant("낙원의소바", new List<Menuset>{
            new Menuset("돈까스", 15000.0f, "돈까스"),
            new Menuset("로스카츠", 13000.0f, "돈까스"),
        }),
        new Restaurant("서울카츠 충무로본점", new List<Menuset>{
            new Menuset("등심 카츠", 14000.0f, "돈까스"),
            new Menuset("안심 카츠", 15000.0f, "돈까스"),
        }),
        new Restaurant("모리짱", new List<Menuset>{
            new Menuset("돈코츠라멘", 8000.0f, "라멘"),
            new Menuset("소유라멘", 7000.0f, "라멘"),
        }),
        new Restaurant("도치피자 장충점", new List<Menuset>{
            new Menuset("디아볼라 피자", 24000.0f, "피자"),
            new Menuset("고르곤졸라 피자",22000.0f, "피자"),
        }),
        new Restaurant("미스터피자 충무로점", new List<Menuset>{
            new Menuset("포테이토골드 피자", 31500.0f, "피자"),
            new Menuset("페퍼로니 피자",20500.0f, "피자"),
            new Menuset("콤비네이션 피자",21500.0f, "피자"),
        }),
    };
}
