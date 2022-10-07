﻿using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BankTrader.Infra.CrossCutting.Identity.Model
{
    [DebuggerDisplay("{Type}-{KeyId}")]
    public class KeyMaterial
    {
        public KeyMaterial() { }
        public KeyMaterial(CryptographicKey cryptographicKey)
        {
            CreationDate = DateTime.UtcNow;
            Parameters = JsonSerializer.Serialize(cryptographicKey.GetJsonWebKey(), typeof(JsonWebKey));
            Type = cryptographicKey.Algorithm.Kty();
            KeyId = cryptographicKey.Key.KeyId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string KeyId { get; set; }
        public string Type { get; set; }
        public string Parameters { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpiredAt { get; set; }

        public JsonWebKey GetSecurityKey() => JsonSerializer.Deserialize<JsonWebKey>(Parameters);

        public void Revoke()
        {
            var jsonWebKey = GetSecurityKey();
            var publicWebKey = PublicJsonWebKey.FromJwk(jsonWebKey);
            ExpiredAt = DateTime.UtcNow;
            IsRevoked = true;
            Parameters = JsonSerializer.Serialize(publicWebKey.ToNativeJwk(), new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault });
        }

        public bool IsExpired(int valueDaysUntilExpire)
        {
            return CreationDate.AddDays(valueDaysUntilExpire) < DateTime.UtcNow.Date;
        }


        public static implicit operator SecurityKey(KeyMaterial value) => value.GetSecurityKey();
    }
}
