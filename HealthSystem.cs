public class HealthSystem
{
    // Start is called before the first frame update
    private int health;
    private int maxHealth;

    public HealthSystem(int health) {
        this.health = health;
        maxHealth = health;
    } 

    public int getHealth() {
        return health;
    } 

    public int getmaxHealth() {
        return maxHealth;
    }

    public void setHealth(int amt) {
        this.health = amt;
    }

    public void Damage(int amt) {
        health -= amt;
        if (health < 0) {
            health = 0;
        }
    }

    public void Heal(int heal) {
        health += heal;
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    public float getHealthPercent() {
        return (float) health / maxHealth;
    }
}
