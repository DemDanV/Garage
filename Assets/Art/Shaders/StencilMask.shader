Shader "Custom/StencilMask"
{
    SubShader
    {
        Tags { "Queue" = "Geometry-1" } // Render the mask before geometry objects

        // Stencil settings to write mask value to the stencil buffer
        Stencil
        {
            Ref 1           // Reference value for mask
            Comp Always      // Always write to stencil
            Pass Replace     // Replace stencil buffer value with reference
        }

        // No rendering; this shader only writes to the stencil buffer
        ColorMask 0
        ZWrite Off
        ZTest Always

        // Empty pass to prevent rendering and disable shadows
        Pass
        {
            Tags { "LightMode" = "ForwardBase" } // Standard rendering mode, but no drawing
            ColorMask 0                          // Disable color output
            ZWrite Off                           // Disable writing to the depth buffer
            Cull Off                             // Disable face culling to prevent any rendering
            ZTest Always                         // Always pass the depth test
        }

        // Shadow caster pass to prevent shadow casting
        Pass
        {
            Tags { "LightMode" = "ShadowCaster" }
            ColorMask 0    // Disable color writing
            ZWrite Off     // Disable writing to the depth buffer
            Cull Off       // Disable backface culling
        }
    }
}
