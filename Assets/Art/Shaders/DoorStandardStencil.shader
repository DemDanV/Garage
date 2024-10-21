Shader "Custom/DoorStandardStencil"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _BumpMap("Normal Map", 2D) = "bump" {}
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        // Stencil settings to handle clipping
        Stencil
        {
            Ref 1        // Reference value for stencil buffer
            Comp NotEqual // Render only if stencil value is not 1
            Pass Keep    // Keep the current stencil buffer value
        }

        // Standard surface shader block
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows addshadow

        sampler2D _MainTex;
        sampler2D _BumpMap;
        fixed4 _Color;
        half _Glossiness;
        half _Metallic;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            o.Alpha = c.a;
        }
        ENDCG

            // Shadow caster pass
            Pass
            {
                Name "ShadowCaster"
                Tags { "LightMode" = "ShadowCaster" }

                Stencil
                {
                    Ref 1
                    Comp NotEqual
                    Pass Keep
                }
            }
    }

        FallBack "Diffuse"
}
