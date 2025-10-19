using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SpellLearningContext : DbContext
    {
        public SpellLearningContext()
        {
        }

        public SpellLearningContext(DbContextOptions<SpellLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeckSlot> DeckSlots { get; set; } = null!;
        public virtual DbSet<GachaPull> GachaPulls { get; set; } = null!;
        public virtual DbSet<GameSafe> GameSaves { get; set; } = null!;
        public virtual DbSet<Spell> Spells { get; set; } = null!;
        public virtual DbSet<Trace> Traces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserClickerUpgrade> UserClickerUpgrades { get; set; } = null!;
        public virtual DbSet<UserDeck> UserDecks { get; set; } = null!;
        public virtual DbSet<UserInventory> UserInventories { get; set; } = null!;
        public virtual DbSet<UserUpgrade> UserUpgrades { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeckSlot>(entity =>
            {
                entity.HasKey(e => e.SlotId)
                    .HasName("deck_slots_pkey");

                entity.ToTable("deck_slots");

                entity.HasIndex(e => e.DeckId, "idx_deck_slots_deck_id");

                entity.Property(e => e.SlotId).HasColumnName("slot_id");

                entity.Property(e => e.DeckId).HasColumnName("deck_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.SlotNumber).HasColumnName("slot_number");

                entity.HasOne(d => d.Deck)
                    .WithMany(p => p.DeckSlots)
                    .HasForeignKey(d => d.DeckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_slots_deck_id_fkey");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.DeckSlots)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_slots_inventory_id_fkey");
            });

            modelBuilder.Entity<GachaPull>(entity =>
            {
                entity.HasKey(e => e.PullId)
                    .HasName("gacha_pulls_pkey");

                entity.ToTable("gacha_pulls");

                entity.HasIndex(e => e.SpellId, "idx_gacha_pulls_spell_id");

                entity.HasIndex(e => e.UserId, "idx_gacha_pulls_user_id");

                entity.Property(e => e.PullId).HasColumnName("pull_id");

                entity.Property(e => e.PullDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("pull_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SpellId).HasColumnName("spell_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.GachaPulls)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gacha_pulls_spell_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GachaPulls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gacha_pulls_user_id_fkey");
            });

            modelBuilder.Entity<GameSafe>(entity =>
            {
                entity.HasKey(e => e.SaveId)
                    .HasName("game_saves_pkey");

                entity.ToTable("game_saves");

                entity.HasIndex(e => e.UserId, "idx_game_saves_user_id");

                entity.Property(e => e.SaveId).HasColumnName("save_id");

                entity.Property(e => e.EquippedDeckId).HasColumnName("equipped_deck_id");

                entity.Property(e => e.HighScore)
                    .HasColumnName("high_score")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SaveData).HasColumnName("save_data");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.EquippedDeck)
                    .WithMany(p => p.GameSaves)
                    .HasForeignKey(d => d.EquippedDeckId)
                    .HasConstraintName("game_saves_equipped_deck_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameSaves)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_saves_user_id_fkey");
            });

            modelBuilder.Entity<Spell>(entity =>
            {
                entity.ToTable("spells");

                entity.Property(e => e.SpellId).HasColumnName("spell_id");

                entity.Property(e => e.BaseDamage)
                    .HasColumnName("base_damage")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CostAmount)
                    .HasColumnName("cost_amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CostCurrency)
                    .HasMaxLength(10)
                    .HasColumnName("cost_currency")
                    .HasDefaultValueSql("'click'::character varying");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GameEffectCode).HasColumnName("game_effect_code");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("image_url");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Rarity)
                    .HasMaxLength(20)
                    .HasColumnName("rarity")
                    .HasDefaultValueSql("'обычная'::character varying");
            });

            modelBuilder.Entity<Trace>(entity =>
            {
                entity.HasKey(e => e.TradeId)
                    .HasName("traces_pkey");

                entity.ToTable("traces");

                entity.HasIndex(e => e.UserIdOffer, "idx_traces_user_offer");

                entity.HasIndex(e => e.UserIdReceive, "idx_traces_user_receive");

                entity.Property(e => e.TradeId).HasColumnName("trade_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InventoryIdOffer).HasColumnName("inventory_id_offer");

                entity.Property(e => e.InventoryIdWant).HasColumnName("inventory_id_want");

                entity.Property(e => e.ResolvedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("resolved_at");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'ожидание'::character varying");

                entity.Property(e => e.UserIdOffer).HasColumnName("user_id_offer");

                entity.Property(e => e.UserIdReceive).HasColumnName("user_id_receive");

                entity.HasOne(d => d.InventoryIdOfferNavigation)
                    .WithMany(p => p.TraceInventoryIdOfferNavigations)
                    .HasForeignKey(d => d.InventoryIdOffer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("traces_inventory_id_offer_fkey");

                entity.HasOne(d => d.InventoryIdWantNavigation)
                    .WithMany(p => p.TraceInventoryIdWantNavigations)
                    .HasForeignKey(d => d.InventoryIdWant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("traces_inventory_id_want_fkey");

                entity.HasOne(d => d.UserIdOfferNavigation)
                    .WithMany(p => p.TraceUserIdOfferNavigations)
                    .HasForeignKey(d => d.UserIdOffer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("traces_user_id_offer_fkey");

                entity.HasOne(d => d.UserIdReceiveNavigation)
                    .WithMany(p => p.TraceUserIdReceiveNavigations)
                    .HasForeignKey(d => d.UserIdReceive)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("traces_user_id_receive_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "idx_users_email");

                entity.HasIndex(e => e.Username, "idx_users_username");

                entity.HasIndex(e => e.Email, "users_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "users_username_key")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrencyClick)
                    .HasColumnName("currency_click")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CurrencyGame)
                    .HasColumnName("currency_game")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_login");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .HasColumnName("password_hash");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserClickerUpgrade>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UpgradeId })
                    .HasName("user_clicker_upgrades_pkey");

                entity.ToTable("user_clicker_upgrades");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UpgradeId).HasColumnName("upgrade_id");

                entity.Property(e => e.PurchasedLast)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("purchased_last")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.Upgrade)
                    .WithMany(p => p.UserClickerUpgrades)
                    .HasForeignKey(d => d.UpgradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_clicker_upgrades_upgrade_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClickerUpgrades)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_clicker_upgrades_user_id_fkey");
            });

            modelBuilder.Entity<UserDeck>(entity =>
            {
                entity.HasKey(e => e.DeckId)
                    .HasName("user_decks_pkey");

                entity.ToTable("user_decks");

                entity.Property(e => e.DeckId).HasColumnName("deck_id");

                entity.Property(e => e.DeckName)
                    .HasMaxLength(100)
                    .HasColumnName("deck_name");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDecks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_decks_user_id_fkey");
            });

            modelBuilder.Entity<UserInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("user_inventory_pkey");

                entity.ToTable("user_inventory");

                entity.HasIndex(e => e.SpellId, "idx_user_inventory_spell_id");

                entity.HasIndex(e => e.UserId, "idx_user_inventory_user_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.ObtainedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("obtained_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SpellId).HasColumnName("spell_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.UserInventories)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_inventory_spell_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInventories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_inventory_user_id_fkey");
            });

            modelBuilder.Entity<UserUpgrade>(entity =>
            {
                entity.HasKey(e => e.UpgradeId)
                    .HasName("user_upgrades_pkey");

                entity.ToTable("user_upgrades");

                entity.Property(e => e.UpgradeId).HasColumnName("upgrade_id");

                entity.Property(e => e.CostClick)
                    .HasColumnName("cost_click")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PowerMultiplier)
                    .HasPrecision(5, 2)
                    .HasColumnName("power_multiplier")
                    .HasDefaultValueSql("1.0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}