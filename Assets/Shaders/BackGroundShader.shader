Shader "Unlit/BackGroundShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		// _DetailTex ("Texture", 2D) = "white" {}
		// _ScrollX ("bg layer Scroll Speed (X)", Float) = 1.0
		_ScrollY ("bg layer Scroll Speed (Y)", Float) = 1.0
		// _Scroll2X ("2nd layer Scroll Speed (X)", Float) = 1.0
		// _Scroll2Y ("2nd layer Scroll Speed (Y)", Float) = 1.0
		_Multiplier ("Multiplier", Float) = 1.0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			// Blend One One
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct a2v
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				// UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			// sampler2D _DetailTex;
			float4 _MainTex_ST;
			float4 _DetailTex_ST;
			// float _ScrollX;
			float _ScrollY;
			// float _Scroll2X;
			// float _Scroll2Y;
			float _Multiplier;
			
			v2f vert (a2v v)
			{
				v2f o;
				// o.vertex = UnityObjectToClipPos(v.vertex);
				// o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				// UNITY_TRANSFER_FOG(o,o.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex) + frac(float2(0.0, _ScrollY) * _Time.y);
				// o.uv.zw = TRANSFORM_TEX(v.uv, _DetailTex) + frac(float2(_Scroll2X, _Scroll2Y) * _Time.y);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// // sample the texture
				// fixed4 col = tex2D(_MainTex, i.uv);
				// // apply fog
				// UNITY_APPLY_FOG(i.fogCoord, col);
				// fixed4 firstLayer = tex2D(_MainTex, i.uv.xy);
				// fixed4 secondLayer = tex2D(_DetailTex, i.uv.zw);
				fixed4 col = tex2D(_MainTex, i.uv);
				// c.rgb *= _Multiplier;
				return col;
			}
			ENDCG
		}
	}
	FallBack "VertexLit"
}
